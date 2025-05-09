using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraThirdPersonMove : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    
    private Tween _moveTween;
    private Tween _rotateTween;

    public void Move(Transform point, float duration, Action OnCompleate = null, Ease ease = Ease.Flash)
    {
        _moveTween?.Kill();
        _moveTween = _cameraPosition.DOMove(point.position, duration)
            .SetEase(ease);
        if (OnCompleate != null)
            _moveTween.OnComplete(() => { OnCompleate?.Invoke(); });
    }

    public void Rotate(Vector3 eulerAngles, float duration, Action OnCompleate = null, Ease ease = Ease.Flash)
    {
        _rotateTween?.Kill();
        _rotateTween = _cameraPosition.DORotate(eulerAngles, duration)
            .SetEase(ease);
        if (OnCompleate != null)
            _rotateTween.OnComplete(() => { OnCompleate?.Invoke(); });
    }

    private void OnDisable()
    {
        _moveTween?.Kill();
        _rotateTween?.Kill();
    }
}