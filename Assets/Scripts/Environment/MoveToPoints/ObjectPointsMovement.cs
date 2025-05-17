using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPointsMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _objectMoveSpeed;
    private int _currentPoint;
    private void Update()
    {
        if (Vector3.Distance(transform.position, _points[_currentPoint].position) <= 1)
        {
            if (_currentPoint == _points.Length - 1)
            {
                _currentPoint = 0;
            }
            else
            {
                _currentPoint++;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position,
            _objectMoveSpeed * Time.deltaTime);
    }
}
