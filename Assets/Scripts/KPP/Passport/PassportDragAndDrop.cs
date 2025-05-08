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
    [SerializeField] private PlayerDragAndDrop _dragAndDrop;
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private float _fireTime;

    private Vector3 _defaultPoint;

    private void Awake()
    {
        _defaultPoint = transform.position;
    }

    private void OnEnable()
    {
        _dragAndDrop.Character.Dead += OnCharacterDead;
        _dragAndDropObject.PickedUp += OnPickuped;
        _dragAndDropObject.DropedDown += OnDropedDown;
    }

    private void OnCharacterDead()
    {
        
        Debug.LogError("Fire");
        StopAllCoroutines();
        _fire.Play();
        StartCoroutine(Firing());
    }

    private IEnumerator Firing()
    {
        yield return new WaitForSeconds(_fireTime);
        _fire.Stop();
        transform.position = _defaultPoint;
        gameObject.SetActive(false);
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
        _dragAndDrop.Character.Dead -= OnCharacterDead;
        _dragAndDropObject.PickedUp -= OnPickuped;
        _dragAndDropObject.DropedDown -= OnDropedDown;
    }
}