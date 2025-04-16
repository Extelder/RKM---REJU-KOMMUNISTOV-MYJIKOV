using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterCheckWatch : MonoBehaviour
{
    [SerializeField] private TwoBoneIKConstraint _ik;
    [SerializeField] private float _weightChangeSpeed;

    private float _targetWeight = 0;

    private void Update()
    {
        _ik.weight = Mathf.Lerp(_ik.weight, _targetWeight, _weightChangeSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.T))
        {
            _targetWeight = 1;
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            _targetWeight = 0;
        }
    }
}