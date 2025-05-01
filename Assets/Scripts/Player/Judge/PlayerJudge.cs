using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerJudge : MonoBehaviour
{
    [SerializeField] private Ease _moveEase;

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerJudgeAnimator _judgeAnimator;
    [SerializeField] private Confirmable _ban;
    [SerializeField] private Confirmable _pass;
    [SerializeField] private Confirmable _break;
    [SerializeField] private Collider _judgeCollider;

    [SerializeField] private float _moveSpeed;

    private bool _selecting;
    private bool _confirming;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private Tween _moveTween;

    private Vector3 _defaultPosition;

    private void Start()
    {
        _defaultPosition = transform.position;
    }


    public void Confirm()
    {
        if (_moveTween == null)
            return;
        if (_moveTween.active)
        {
            _moveTween.OnComplete(() =>
            {
                _animator.SetBool("IsSelecting", false);
                _selecting = false;
                _animator.SetTrigger("Confirm");
            });
            return;
        }

        _selecting = false;

        _animator.SetBool("IsSelecting", false);

        _animator.SetTrigger("Confirm");
    }

    private void OnEnable()
    {
        _judgeAnimator.Confirmed += Confirmed;
        _judgeCollider.OnMouseDownAsObservable().Subscribe(_ =>
        {
            _selecting = !_selecting;
            _animator.SetBool("IsSelecting", _selecting);
            _animator.ResetTrigger("Confirm");
        }).AddTo(_disposable);

        _ban.OnMouseDownAsObservable().Subscribe(_ => { Confirm(); }).AddTo(_disposable);

        _pass.OnMouseDownAsObservable().Subscribe(_ => { Confirm(); }).AddTo(_disposable);
        _break.OnMouseDownAsObservable().Subscribe(_ => { Confirm(); }).AddTo(_disposable);

        _ban.OnMouseEnterAsObservable().Subscribe(_ =>
        {
            if (!_selecting)
                return;
            _moveTween?.Kill();
            _moveTween = transform.DOMove(_ban.JudgeTransform.position, _moveSpeed).SetEase(_moveEase);
        }).AddTo(_disposable);

        _pass.OnMouseEnterAsObservable().Subscribe(_ =>
        {
            if (!_selecting)
                return;
            _moveTween?.Kill();
            _moveTween = transform.DOMove(_pass.JudgeTransform.position, _moveSpeed).SetEase(_moveEase);
        }).AddTo(_disposable);

        _break.OnMouseEnterAsObservable().Subscribe(_ =>
        {
            if (!_selecting)
                return;
            _moveTween?.Kill();
            _moveTween = transform.DOMove(_break.JudgeTransform.position, _moveSpeed).SetEase(_moveEase);
        }).AddTo(_disposable);
    }

    public void Confirmed()
    {
        _moveTween?.Kill();
        _moveTween = transform.DOMove(_defaultPosition, _moveSpeed).SetEase(_moveEase);
    }

    private void OnDisable()
    {
        _judgeAnimator.Confirmed -= Confirmed;
        _moveTween?.Kill();
        _disposable.Clear();
    }
}