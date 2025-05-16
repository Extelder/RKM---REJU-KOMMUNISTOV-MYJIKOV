using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirtsDayEvent : DayEventable
{
    [SerializeField] private GameObject _jarahov;
    [SerializeField] private AudioSource _allertAudio;


    public override void DayStartedEvent()
    {
    }

    public override void DayEndedEvent()
    {
        _allertAudio.Play(); 
        _jarahov.SetActive(true);
    }
}
