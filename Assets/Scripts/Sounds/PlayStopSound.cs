using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStopSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound()
    {
        _audioSource.Play();
    }
    public void StopSound()
    {
        _audioSource.Stop();
    }
}
