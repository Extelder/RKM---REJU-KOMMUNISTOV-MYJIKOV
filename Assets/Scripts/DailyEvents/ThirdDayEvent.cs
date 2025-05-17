using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdDayEvent : DayEventable
{
    [SerializeField] private GameObject _allDay;
    public override void DayStartedEvent()
    {
        
    }

    public override void DayEndedEvent()
    {
        _allDay.SetActive(true);
    }
}
