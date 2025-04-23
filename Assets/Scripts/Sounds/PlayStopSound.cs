using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStopSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _defaultClip;
    [SerializeField] private AudioClip _secondClip;

    public void PlaySound()
    {
        _audioSource.Play();
    }
    public void StopSound()
    {
        _audioSource.Stop();
    }

    public void SwitchClipToDefault()
    {
        _audioSource.clip = _defaultClip;
    }

    public void SwitchClip()
    {
        _audioSource.clip = _secondClip;
    }
}
