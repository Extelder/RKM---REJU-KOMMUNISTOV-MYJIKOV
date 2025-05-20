using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FithDayEvent : DayEventable
{
    [SerializeField] private GameObject _fbi;
    [SerializeField] private FBIMove _fbiMove;
    
    public override void DayStartedEvent()
    {
        _fbi.SetActive(true);
        _fbiMove.MoveToDestination();   
    }

    public override void DayEndedEvent()
    {
    }
}
