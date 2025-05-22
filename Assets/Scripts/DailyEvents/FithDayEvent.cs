using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class FithDayEvent : DayEventable
{
    [SerializeField] private GameObject _fbi;
    [SerializeField] private DragAndDropSeat _dragAndDropSeat;
    
    public override void DayStartedEvent()
    {
    }

    public override void DayEndedEvent()
    {
        _dragAndDropSeat.CanStandUp = false;
        _fbi.SetActive(true);
    }
}
