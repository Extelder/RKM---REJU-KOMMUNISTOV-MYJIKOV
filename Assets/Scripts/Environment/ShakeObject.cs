using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _strength;
    [SerializeField] private int _vibration;
    
    private Tween _tween;

    public void Shake()
    {
        _tween = transform.DOShakePosition(_duration, _strength, _vibration);
    }

    private void OnDisable()
    {
        _tween?.Kill();
    }
}
