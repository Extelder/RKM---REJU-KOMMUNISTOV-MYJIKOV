using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSound : MonoBehaviour
{
    [SerializeField] private KPPShotgun _shotgun;
    [SerializeField] private AudioSource _shootAudio;

    private void OnEnable()
    {
        _shotgun.Shooted += OnShooted;
    }

    private void OnShooted()
    {
        _shootAudio.Play();
    }

    private void OnDisable()
    {
        _shotgun.Shooted -= OnShooted;
    }
}