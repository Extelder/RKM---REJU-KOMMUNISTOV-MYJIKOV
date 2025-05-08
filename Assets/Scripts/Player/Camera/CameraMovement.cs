using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [HideInInspector] public float Lookvertical;
    [HideInInspector] public float Lookhorizontal;

    [SerializeField] private PlayerController _controller;
    [SerializeField] private Transform Camera;
    [SerializeField, Range(10, 120)] private float lookXLimit = 80.0f;
    [SerializeField, Range(10, 120)] private float lookYLimit = 80.0f;


    private float _rotationX = 0;
    private float _rotationY = 0;


    private void Update()
    {
        Lookvertical = -Input.GetAxis("Mouse Y");
        Lookhorizontal = Input.GetAxis("Mouse X");

        _rotationX += Lookvertical * _controller.lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
        _rotationY += Lookhorizontal * _controller.lookSpeed;
        _rotationY = Mathf.Clamp(_rotationY, -lookYLimit, lookYLimit);
        Camera.transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
    }
}
