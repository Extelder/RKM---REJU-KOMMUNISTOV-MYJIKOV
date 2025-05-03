using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunVFX : MonoBehaviour
{
    [SerializeField] private KPPShotgun _kppShotgun;
    [SerializeField] private ParticleSystem _shootVFX;

    private void OnEnable()
    {
        _kppShotgun.Shooted += OnShooted;
    }

    private void OnShooted()
    {
        _shootVFX.Play();
    }

    private void OnDisable()
    {
        _kppShotgun.Shooted -= OnShooted;
    }
}