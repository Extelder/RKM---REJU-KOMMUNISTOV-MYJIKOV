using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HandDoorOpenChecker : MonoBehaviour
{
    [SerializeField] private TwoBoneIKConstraint _ik;
    [SerializeField] private float _weightChangeSpeed;
    [SerializeField] private AudioSource _doorSound;

    private float _tagetWeight;

    private void Update()
    {
        _ik.weight = Mathf.Lerp(_ik.weight, _tagetWeight, _weightChangeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            _tagetWeight = 1;
            _doorSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            _tagetWeight = 0;
        }
    }
}