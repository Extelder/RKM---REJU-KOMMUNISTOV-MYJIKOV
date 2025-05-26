using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDeathDailyEvent : DayEventable
{
    [SerializeField] private GameObject _passButton;
    [SerializeField] private GameObject _banButton;

    public override void DayStartedEvent()
    {
        _passButton.SetActive(false);
        _banButton.SetActive(false);
    }

    public override void DayEndedEvent()
    {
    }
}