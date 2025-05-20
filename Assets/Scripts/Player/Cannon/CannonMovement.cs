using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] private Transform _cannonShootPart;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerSeatPlace _playerSeatPlace;

            
    private float _rotationX;
    private float _rotationY;

    private void Awake()
    {
        _rotationX = _cannonShootPart.transform.localRotation.x;
        _rotationY = transform.localRotation.y;
    }

    private void Update()
    {
        if(!_playerSeatPlace.CanUseThirdPerson)
        {
            float lookvertical = -Input.GetAxis("Vertical");
            float lookhorizontal = Input.GetAxis("Horizontal");

            _rotationX += lookvertical * _speed;
            _rotationX = Mathf.Clamp(_rotationX, 225, 270);
            _rotationY += lookhorizontal * _speed;
            _rotationY = Mathf.Clamp(_rotationY, -135, -45);
            _cannonShootPart.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
        }
    }
}
