using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Animations;

public class KPPCharacterGoHomeState : KPPCharacterAnimatorState
{
    [SerializeField] private KPPCharacterMove _characterMove;
    [SerializeField] private LookAtConstraint _lookAtPlayer;
    [SerializeField] private GameObject _mainParent;
    [SerializeField] private KPPCharacterStateMachine _characterStateMachine;
    [SerializeField] private Transform _outPoint;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _rotateDuration;
    [SerializeField] private float _goHomeWeight;
    [SerializeField] private float _goHomeWeightLerpSpeed;

    [SerializeField] private GameObject _paperInHand;
    [SerializeField] private GameObject _paperOnTable;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        _paperOnTable = DragAndDropData.Instance.PassportMain;
    }

    public override void Enter()
    {
        Animator.TakePapers();
        Animator.PaperTaked += OnPaperTaked;
    }

    public override void Exit()
    {
        Animator.PaperTaked -= OnPaperTaked;
        _disposable.Clear();
    }

    private void OnPaperTaked()
    {
        _paperOnTable.SetActive(false);
        _paperInHand.SetActive(true);

        _characterMove.Rotate(_outPoint.eulerAngles, _rotateDuration,
            () =>
            {
                Observable.EveryUpdate().Subscribe(_ =>
                {
                    _lookAtPlayer.weight =
                        Mathf.Lerp(_lookAtPlayer.weight, _goHomeWeight, _goHomeWeightLerpSpeed * Time.deltaTime);
                }).AddTo(_disposable);

                Animator.Walk();

                _characterMove.Move(_outPoint, _moveDuration,
                    () => { Destroy(_mainParent); });
            });
    }

    private void OnDisable()
    {
        _disposable.Clear();
        Animator.PaperTaked -= OnPaperTaked;
    }
}