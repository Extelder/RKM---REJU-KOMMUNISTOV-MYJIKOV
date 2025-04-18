using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed;

    [SerializeField] private Vector3 _upEulerAngles;
    [SerializeField] private Vector3 _downEulerAngles;

    private Vector3 _targetEulerAngles;

    private void Start()
    {
        _targetEulerAngles = _downEulerAngles;
    }

    private void OnEnable()
    {
        _camera.localEulerAngles = _upEulerAngles;
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
            LookUp();
        if (Input.mouseScrollDelta.y < 0)
            LookDown();
        _camera.localEulerAngles = Vector3.Lerp(_camera.localEulerAngles, _targetEulerAngles, _speed * Time.deltaTime);
    }

    public void LookUp()
    {
        _targetEulerAngles = _upEulerAngles;
    }

    public void LookDown()
    {
        _targetEulerAngles = _downEulerAngles;
    }
}