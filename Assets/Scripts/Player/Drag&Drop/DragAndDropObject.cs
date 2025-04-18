using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DragAndDropObject : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private PlayerDragAndDrop _playerDragAndDrop;
    private Quaternion _defaultRotation;

    private Rigidbody _rigidBody;

    private bool _moving;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _defaultRotation = transform.localRotation;
    }

    private void OnMouseExit()
    {
        _playerDragAndDrop.ObjectExited(this);
    }

    private void OnMouseOver()
    {
        _playerDragAndDrop.ObjectEntered(this);
    }

    private void OnMouseDown()
    {
        _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        _playerDragAndDrop.ObjectStartDragged(this);
        _disposable.Clear();
        Observable.EveryUpdate().Subscribe(_ =>
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _defaultRotation,
                _rotateSpeed * Time.deltaTime);
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }

    public void DragEnded()
    {
        _disposable.Clear();
        _rigidBody.constraints = RigidbodyConstraints.None;
    }

    private void OnMouseUp()
    {
        _moving = false;
    }
}