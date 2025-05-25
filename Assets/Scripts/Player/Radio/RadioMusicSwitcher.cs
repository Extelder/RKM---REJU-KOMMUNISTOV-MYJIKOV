using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RadioMusicSwitcher : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip[] _soundClips;
    [SerializeField] private string[] _soundNames;
    [SerializeField] private GameObject _redSphere;
    [SerializeField] private GameObject _greenSphere;
    [SerializeField] private TextMeshProUGUI _text;
    public int Index { get; set; }

    public void Interact()
    {
        Index++;
        _musicSource.Stop();
        _text.gameObject.SetActive(false);
        if (Index > _soundClips.Length-1)
        {
            Index = 0;
        }
        Debug.Log(Index);
        _musicSource.clip = _soundClips[Index];
        _text.text = _soundNames[Index];
        _musicSource.Play();
        _text.gameObject.SetActive(true);
        _redSphere.SetActive(false);
        _greenSphere.SetActive(true);
    }
}
