using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhDay : DayEventable
{
    [SerializeField] private ShakeObject[] _shakeObject;
    [SerializeField] private GameObject _brainRot;
    [SerializeField] private AudioSource _brainRotSound;
    [SerializeField] private AudioSource _allert;
    public override void DayStartedEvent()
    {
        
        _brainRot.SetActive(true);
        _brainRotSound.Play();
        _allert.Stop();
        for (int i = 0; i < _shakeObject.Length; i++)
        {
            _shakeObject[i].Shake();
        }
    }

    public override void DayEndedEvent()
    {
    }
}
