using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveObjectTween : MonoBehaviour
{
    [SerializeField] private Transform _objectTransform;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _cutScene;
    [SerializeField] private GameObject _dragAndDrop;

    private Tween _moveTween;

    public void MoveObject()
    {
        _moveTween = _objectTransform.DOMove(_targetPoint.position, _duration).OnComplete((() =>
        {
            _dragAndDrop.SetActive(false);
            _cutScene.SetActive(true);
        }));
    }

    private void OnDisable()
    {
        _moveTween?.Kill();
    }
}
