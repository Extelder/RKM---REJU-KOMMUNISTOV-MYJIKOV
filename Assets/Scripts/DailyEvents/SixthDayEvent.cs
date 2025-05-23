using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthDayEvent : DayEventable
{
    [SerializeField] private GameObject _tv;
    [SerializeField] private AudioSource _allertSound;
    
    public override void DayStartedEvent()
    {
        
    }

    public override void DayEndedEvent()
    {
        _tv.SetActive(true);
        Invoke(nameof(StopAllert), 2);
    }

    private void StopAllert()
    {
        _allertSound.Stop();
    }
}
