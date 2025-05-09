using System;
using DG.Tweening;
using EvolveGames;
using UniRx;
using UnityEngine;

public class CameraThirdPerson : RaycastBehaviour
{
    [SerializeField] private CameraThirdPersonMove _cameraThirdPersonMove;
    [SerializeField] private Ease _ease;
    [SerializeField] private Transform _cameraTargetPoint;
    [SerializeField] private Transform _cameraStartPoint;
    [SerializeField] private Transform _selfiePoint;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _duration;
    [SerializeField] private KeyCode _key;
    [SerializeField] private GameObject[] _head;
    [SerializeField] private PlayerSeatPlace _playerSeat;
    private bool _instantlyEnded;
    private Transform _currentPoint;
    private CompositeDisposable _disposable = new CompositeDisposable();

    public event Action EnteredFirstPerson;
    public event Action ExitedFirstPerson;
    private void Start()
    {
        GoToThirdPerson();
        _currentPoint = _cameraTargetPoint;
    }

    private void GoToThirdPerson()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(_key) && _playerSeat.CanUseThirdPerson)
            {
                StartThirdPerson();
            }
            else if (Input.GetKeyUp(_key) && !_instantlyEnded)
            {
                EndThirdPerson();
            }
            else if (Input.GetKey(_key) && _playerController.Moving.Value)
            {
                InstantlyEndThirdPerson();
            }
            if (GetHitCollider(out Collider collider))
            {
                MakeSelfie();
            }
            else
            {
                _currentPoint = _cameraTargetPoint;
            }
        }).AddTo(_disposable);
    }

    private void StartThirdPerson()
    {
        _playerController.canMove = false;
        _instantlyEnded = false;
        MoveAndRotate(_currentPoint, ((() =>
        {
            EnteredFirstPerson?.Invoke();
        })));
        SetActiveHead(true);
    }

    private void EndThirdPerson()
    {
        ExitedFirstPerson?.Invoke();
        MoveAndRotate(_cameraStartPoint, (() =>
        {
            _playerController.canMove = true;
            SetActiveHead(false);
        }));
    }

    private void InstantlyEndThirdPerson()
    {
        ExitedFirstPerson?.Invoke();
        _playerController.canMove = true;
        SetActiveHead(false);
        _instantlyEnded = true;
        transform.position = _cameraStartPoint.position;
        transform.localEulerAngles = _cameraStartPoint.localEulerAngles;
    }

    private void MoveAndRotate(Transform transform, Action PositionComplete)
    {
        _cameraThirdPersonMove.Move(transform, _duration, (() =>
        {
            PositionComplete?.Invoke();
        }));
        _cameraThirdPersonMove.Rotate(transform.eulerAngles, _duration, null, _ease);

    }

    private void SetActiveHead(bool active)
    {
        if(_playerSeat.CanUseThirdPerson)
        {
            for (int i = 0; i < _head.Length; i++)
            {
                _head[i].SetActive(active);
            }
        }
    }

    private void MakeSelfie()
    {
        _currentPoint = _selfiePoint;
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}
