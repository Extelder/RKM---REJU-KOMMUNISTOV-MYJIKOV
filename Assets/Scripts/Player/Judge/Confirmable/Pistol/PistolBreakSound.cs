using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBreakSound : MonoBehaviour
{
    [SerializeField] private PistolBreak _pistolBreak;
    [SerializeField] private AudioSource _breakSource;

    private void OnEnable()
    {
        _pistolBreak.Confirmed += OnConfirmed;
    }

    private void OnConfirmed()
    {
        _breakSource.Play();
    }

    private void OnDisable()
    {
        _pistolBreak.Confirmed -= OnConfirmed;
    }
}