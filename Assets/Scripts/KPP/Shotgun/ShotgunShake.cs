using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[Serializable]
public struct ShakePreset
{
    public float Duration;
    public float Strength;
    public int Vibrato;
    public float Randomness;
}

public class ShotgunShake : MonoBehaviour
{
    [SerializeField] private KPPShotgun _kppShotgun;
    [SerializeField] private Camera _camera;

    [SerializeField] private ShakePreset _positionPreset;
    [SerializeField] private ShakePreset _rotationPreset;


    private void OnEnable()
    {
        _kppShotgun.Shooted += OnShooted;
    }

    private void OnShooted()
    {
        _camera.DOShakePosition(_positionPreset.Duration, _positionPreset.Strength, _positionPreset.Vibrato,
            _positionPreset.Randomness);
        _camera.DOShakeRotation(_rotationPreset.Duration, _rotationPreset.Strength, _rotationPreset.Vibrato,
            _rotationPreset.Randomness);
    }

    private void OnDisable()
    {
        _kppShotgun.Shooted -= OnShooted;
    }
}