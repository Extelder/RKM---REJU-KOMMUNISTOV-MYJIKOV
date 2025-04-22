using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerJudge : MonoBehaviour
{
    [SerializeField] private Ease _moveEase;

    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _banCollider;
    [SerializeField] private Collider _passCollider;
    [SerializeField] private Collider _judgeCollider;

    [SerializeField] private Transform _banTransform;
    [SerializeField] private Transform _passTransform;
    [SerializeField] private float _moveSpeed;

    private bool _selecting;
    private bool _confirming;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private Tween _moveTween;

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
        _judgeCollider.OnMouseDownAsObservable().Subscribe(_ =>
        {
            _selecting = !_selecting;
            _animator.SetBool("IsSelecting", _selecting);
            _animator.ResetTrigger("Confirm");
        }).AddTo(_disposable);

        _banCollider.OnMouseDownAsObservable().Subscribe(_ => { Confirm(); }).AddTo(_disposable);

        _passCollider.OnMouseDownAsObservable().Subscribe(_ => { Confirm(); }).AddTo(_disposable);


        _banCollider.OnMouseEnterAsObservable().Subscribe(_ =>
        {
            if (!_selecting)
                return;
            _moveTween?.Kill();
            _moveTween = transform.DOMove(_banTransform.position, _moveSpeed).SetEase(_moveEase);
        }).AddTo(_disposable);

        _passCollider.OnMouseEnterAsObservable().Subscribe(_ =>
        {
            if (!_selecting)
                return;
            _moveTween?.Kill();
            _moveTween = transform.DOMove(_passTransform.position, _moveSpeed).SetEase(_moveEase);
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _moveTween?.Kill();
        _disposable.Clear();
    }
}