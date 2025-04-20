using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMouse : MonoBehaviour
{
    [SerializeField] private float _checkDeltaRate = 0.1f;
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private Vector3 _localMoveOffset;

    private Vector3 _defautlLocalPoition;

    private Vector3 _previousPosition;
    private Vector3 _deltaPosition;

    private Vector3 _targetPosition;

    private void Start()
    {
        _defautlLocalPoition = transform.localPosition;
        StartCoroutine(MovingMouse());
    }

    private void Update()
    {
        transform.localPosition =
            Vector3.MoveTowards(transform.localPosition, _targetPosition, _lerpSpeed * Time.deltaTime);
    }

    private IEnumerator MovingMouse()
    {
        while (true)
        {
            _previousPosition = Input.mousePosition;
            yield return new WaitForSeconds(_checkDeltaRate);
            _deltaPosition = Input.mousePosition - _previousPosition;
            _deltaPosition *= 100;
            _deltaPosition.Normalize();
            if (_deltaPosition == Vector3.zero)
            {
                _targetPosition = _defautlLocalPoition;
                continue;
            }

            NormalizeVector(ref _deltaPosition);

            _targetPosition = _defautlLocalPoition + new Vector3(_localMoveOffset.x * _deltaPosition.x, 0,
                _localMoveOffset.z * _deltaPosition.y);

        }
    }

    public void NormalizeVector(ref Vector3 vector3)
    {
        if (vector3.x == 0)
            vector3.x = 0;
        else if (vector3.x > 0)
            vector3.x = 1;
        else if (vector3.x < 0)
            vector3.x = -1;

        if (vector3.y == 0)
            vector3.y = 0;
        else if (vector3.y > 0)
            vector3.y = 1;
        else if (vector3.y < 0)
            vector3.y = -1;
    }
}