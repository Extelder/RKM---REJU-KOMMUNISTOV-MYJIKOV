using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioMusicSwitcher : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip[] _soundClips;
    private int _index = 0;

    public void Interact()
    {
        _index++;
        _musicSource.Stop();
        if (_index > _soundClips.Length-1)
        {
            _index = 0;
        }
        Debug.Log(_index);
        _musicSource.clip = _soundClips[_index];
        _musicSource.Play();
    }
}
