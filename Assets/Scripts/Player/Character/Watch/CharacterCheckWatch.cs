using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterCheckWatch : MonoBehaviour
{
    [SerializeField] private TwoBoneIKConstraint _ik;
    [SerializeField] private float _upWeightChangeSpeed;
    [SerializeField] private float _downWeightChangeSpeed;

    private float _targetWeight = 0;
    private float _currentChangeSpeed = 0;

    private void Update()
    {
        _ik.weight = Mathf.Lerp(_ik.weight, _targetWeight, _currentChangeSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentChangeSpeed = _upWeightChangeSpeed;
            _targetWeight = 1;
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            _currentChangeSpeed = _downWeightChangeSpeed;
            _targetWeight = 0;
        }
    }
}