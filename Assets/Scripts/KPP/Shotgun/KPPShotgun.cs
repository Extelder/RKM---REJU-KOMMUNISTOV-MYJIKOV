using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPShotgun : MonoBehaviour
{
    [SerializeField] private PlayerDragAndDrop _dragAndDrop;
    [field: SerializeField] public Transform ShootPivot { get; private set; }

    [SerializeField] private Animator _animator;
    [SerializeField] private string _shootTrigger;
    [SerializeField] private string _takeOutTrigger;
    [SerializeField] private AudioSource _clearBoxSound;

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
        _dragAndDrop.Character.OnShoot();
        Shooted?.Invoke();
    }

    public void ClearBoxSound()
    {
        _clearBoxSound.Play();
    }

    public void OnConfirmed()
    {
        _animator.SetTrigger(_takeOutTrigger);
    }
}