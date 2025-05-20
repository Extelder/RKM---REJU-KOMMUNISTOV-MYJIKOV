using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthDayEvent : DayEventable
{
    [SerializeField] private GameObject _kraken;
    [SerializeField] private AudioSource _piratesMusic;

    public override void DayStartedEvent()
    {
    }

    public override void DayEndedEvent()
    {
        _kraken.SetActive(true);
        _piratesMusic.Play();
    }
}
