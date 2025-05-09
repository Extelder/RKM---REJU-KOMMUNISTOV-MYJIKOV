using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;

public class PlayerSeatPlace : MonoBehaviour, Iinteractable
{
    [SerializeField] private Ease _ease;
    [SerializeField] private GameObject _watches;
    [SerializeField] private GameObject _seatPlace;

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
    
    public bool CanUseThirdPerson { get; private set; }

    private void Awake()
    {
        CanUseThirdPerson = true;
        _collider = GetComponent<Collider>();
    }

    public void Interact()
    {
        StopAllCoroutines();
        _collider.enabled = false;
        _disposable.Clear();

        _moveTween?.Kill();
        _rotateTween?.Kill();

        camera = PlayerCharacter.Instance.Camera;

        PlayerCharacter.Instance.DisablePlayer();

        cameraDefaultPosition = camera.position;

        _moveTween = camera.DOMove(_cameraTarget.position, _moveSpeed).SetEase(_ease);

        _rotateTween = camera.DORotate(_cameraTarget.eulerAngles, _moveSpeed).SetEase(_ease).OnComplete(() =>
        {
            CanUseThirdPerson = false;
            _cutSceneCamera.SetActive(true);
            _cutSceneAnimator.SetTrigger("Seat");
            _watches.SetActive(false);
        });
    }

    public void Unseated()
    {
        _cutSceneCamera.SetActive(false);
        _collider.enabled = true;

        StartCoroutine(WaitingFOrMove());
    }
    
    
    public void EnableSeat()
    {
        _cutSceneCamera.SetActive(false);
        _seatPlace.SetActive(true);
        _disposable.Clear();
        _moveTween?.Kill();
        _rotateTween?.Kill();
        GameCursor.Instance.Hide();


        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _seatPlace.SetActive(false);
                _cutSceneCamera.SetActive(true);
                _cutSceneAnimator.SetTrigger("StandUp");
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }

    private IEnumerator WaitingFOrMove()
    {
        yield return new WaitForSeconds(0.3f);
        yield return new WaitForSeconds(0.3f);
        PlayerCharacter.Instance._controller.canMove = false;
        _moveTween = camera.DOMove(cameraDefaultPosition, _moveSpeed / 2).SetEase(_ease).OnComplete(() =>
        {
            PlayerCharacter.Instance.EnablePlayer();
            _watches.SetActive(true);
            PlayerCharacter.Instance._controller.canMove = true;
            camera.localEulerAngles = new Vector3(0, 0, 0);
            CanUseThirdPerson = true;
        });
    }

    private void OnDisable()
    {
        _disposable.Clear();
        _moveTween?.Kill();
        _rotateTween?.Kill();
    }
}
