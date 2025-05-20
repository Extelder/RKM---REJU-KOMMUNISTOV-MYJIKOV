using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SoundSilenceVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _time;
    private Tween _volumeTween;

    public void SilenceVolume()
    {
        _volumeTween = _audioSource.DOFade(0, _time);
    }

    private void OnDisable()
    {
        _volumeTween?.Kill();
    }
}
