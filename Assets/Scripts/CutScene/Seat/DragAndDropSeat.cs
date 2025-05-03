using System;
using System.Collections;
using DG.Tweening;
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

    private Transform camera;
    private Vector3 cameraDefaultPosition;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void Interact()
    {
        StopAllCoroutines();
        _collider.enabled = false;
        _disposable.Clear();
        _dragAndDropTable.SetActive(false);

        _moveTween?.Kill();
        _rotateTween?.Kill();

        camera = PlayerCharacter.Instance.Camera;

        PlayerCharacter.Instance.DisablePlayer();

        cameraDefaultPosition = camera.position;

        _moveTween = camera.DOMove(_cameraTarget.position, _moveSpeed).SetEase(_ease);

        _rotateTween = camera.DORotate(_cameraTarget.eulerAngles, _moveSpeed).SetEase(_ease).OnComplete(() =>
        {
            _cutSceneCamera.SetActive(true);
            _cutSceneAnimator.SetTrigger("Seat");
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
        GameCursor.Instance.Hide();
        _collider.enabled = true;
        _cutSceneCamera.SetActive(false);

        StartCoroutine(WaitingFOrMove());
    }

    private IEnumerator WaitingFOrMove()
    {
        yield return new WaitForSeconds(0.3f);
        yield return new WaitForSeconds(0.3f);
        PlayerCharacter.Instance.EnablePlayer();
        PlayerCharacter.Instance._controller.canMove = false;
        GameCursor.Instance.Hide();
        _moveTween = camera.DOMove(cameraDefaultPosition, _moveSpeed / 2).SetEase(_ease).OnComplete(() =>
        {
            PlayerCharacter.Instance._controller.canMove = true;
            camera.localEulerAngles = new Vector3(0, 0, 0);
        });
    }

    private void OnDisable()
    {
        _disposable.Clear();

        _moveTween?.Kill();
        _rotateTween?.Kill();
    }
}