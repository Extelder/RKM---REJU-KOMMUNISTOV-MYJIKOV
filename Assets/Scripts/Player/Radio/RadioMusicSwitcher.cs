using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioMusicSwitcher : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip[] _soundClips;
    [SerializeField] private GameObject _redSphere;
    [SerializeField] private GameObject _greenSphere;
    public int Index { get; set; }

    public void Interact()
    {
        Index++;
        _musicSource.Stop();
        if (Index > _soundClips.Length-1)
        {
            Index = 0;
        }
        Debug.Log(Index);
        _musicSource.clip = _soundClips[Index];
        _musicSource.Play();
        _redSphere.SetActive(false);
        _greenSphere.SetActive(true);
    }
}
