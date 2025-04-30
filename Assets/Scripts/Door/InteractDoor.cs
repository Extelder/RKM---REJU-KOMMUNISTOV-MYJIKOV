using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private HingeJoint _hinge;

    private bool _opening;

    private float _defaultDamper;

    private void Start()
    {
        _defaultDamper = _hinge.spring.damper;
    }

    private void Update()
    {
        if ((_hinge.angle >= 89 || _hinge.angle <= -89) && _opening == true)
        {
            _rigidbody.isKinematic = true;
        }
    }

    public void Opening()
    {
        _hinge.useSpring = false;
        _opening = true;
    }

    public void StopOpening()
    {
        _hinge.useSpring = true;
        _opening = false;
        _rigidbody.isKinematic = false;
    }
}