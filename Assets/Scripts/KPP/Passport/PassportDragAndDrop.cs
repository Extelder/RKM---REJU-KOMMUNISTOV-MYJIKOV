using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassportDragAndDrop : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _openBool;
    [SerializeField] private Collider _openCollider;
    [SerializeField] private Collider _closeCollider;

    [SerializeField] private DragAndDropObject _dragAndDropObject;

    private void OnEnable()
    {
        _dragAndDropObject.PickedUp += OnPickuped;
        _dragAndDropObject.DropedDown += OnDropedDown;
    }

    private void OnPickuped()
    {
        _openCollider.enabled = false;
        _closeCollider.enabled = true;
        _animator.SetBool(_openBool, false);
    }

    private void OnDropedDown()
    {
        _openCollider.enabled = true;
        _closeCollider.enabled = false;
        _animator.SetBool(_openBool, true);
    }

    private void OnDisable()
    {
        _dragAndDropObject.PickedUp -= OnPickuped;
        _dragAndDropObject.DropedDown -= OnDropedDown;
    }
}