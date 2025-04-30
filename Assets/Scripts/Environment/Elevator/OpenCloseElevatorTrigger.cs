using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class OpenCloseElevatorTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController PlayerController))
        {
            _animator.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController PlayerController))
        {
            _animator.SetBool("Open", false);
        }
    }
}