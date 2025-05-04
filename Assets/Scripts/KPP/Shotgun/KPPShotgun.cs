using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPShotgun : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _shootTrigger;
    [SerializeField] private string _takeOutTrigger;

    [SerializeField] private PistolBreak _pistol;

    public event Action Shooted;

    private void OnEnable()
    {
        _pistol.Confirmed += OnConfirmed;
    }

    private void OnDisable()
    {
        _pistol.Confirmed -= OnConfirmed;
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger(_shootTrigger);
    }

    public void PerformShoot()
    {
        Shooted?.Invoke();
    }

    public void OnConfirmed()
    {
        _animator.SetTrigger(_takeOutTrigger);
    }
}