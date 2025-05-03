using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPShotgun : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _shootTrigger;

    public event Action Shooted;

    private void OnMouseDown()
    {
        _animator.SetTrigger(_shootTrigger);
    }

    public void PerformShoot()
    {
        Shooted?.Invoke();
    }
}