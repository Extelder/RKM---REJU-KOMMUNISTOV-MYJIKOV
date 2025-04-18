using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EvolveGames;
using UniRx;
using UnityEngine;

public class DragAndDropSeat : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject _dragAndDropTable;
    [SerializeField] private Ease _ease;

    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private GameObject _cutSceneCamera;
    [SerializeField] private Animator _cutSceneAnimator;
    [SerializeField] private float _moveSpeed;

    private Tween _moveTween;
    private Tween _rotateTween;
    private Collider _collider;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void Interact()
    {
        _collider.enabled = false;
        _disposable.Clear();
        _dragAndDropTable.SetActive(false);

        Transform camera = PlayerCharacter.Instance.Camera;

        PlayerCharacter.Instance.DisablePlayer();

        Vector3 cameraDefaultPosition = camera.position;
        Vector3 cameraDefaultRotation = camera.eulerAngles;

        _moveTween = camera.DOMove(_cameraTarget.position, _moveSpeed).SetEase(_ease);

        _rotateTween = camera.DORotate(_cameraTarget.eulerAngles, _moveSpeed).SetEase(_ease).OnComplete(() =>
        {
            _cutSceneCamera.SetActive(true);
            _cutSceneAnimator.SetTrigger("Seat");

            camera.position = cameraDefaultPosition;
            camera.eulerAngles = cameraDefaultRotation;
        });
    }

    public void EnableDragAndDropTable()
    {
        _cutSceneCamera.SetActive(false);
        _dragAndDropTable.SetActive(true);

        _disposable.Clear();
        _moveTween?.Kill();
        _rotateTween?.Kill();

        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _dragAndDropTable.SetActive(false);
                _cutSceneCamera.SetActive(true);

                _cutSceneAnimator.SetTrigger("UnSeat");
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }

    public void Unseated()
    {
        _cutSceneCamera.SetActive(false);
        _collider.enabled = true;

        PlayerCharacter.Instance.EnablePlayer();
    }

    private void OnDisable()
    {
        _disposable.Clear();

        _moveTween?.Kill();
        _rotateTween?.Kill();
    }
}