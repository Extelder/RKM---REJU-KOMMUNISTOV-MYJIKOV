using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDayEvent : DayEventable
{
    [SerializeField] private GameObject _skyscraper;
    [SerializeField] private GameObject _plane;
    [SerializeField] private Animator _planeAnimator;
    [SerializeField] private string _triggerName;
    
    public override void DayStartedEvent()
    {
        _skyscraper.SetActive(true);
    }

    public override void DayEndedEvent()
    {
        _plane.SetActive(true);
        _planeAnimator.SetTrigger(_triggerName);
    }
}
