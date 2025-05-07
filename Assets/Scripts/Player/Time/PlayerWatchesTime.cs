using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWatchesTime : MonoBehaviour
{
    [SerializeField] private float _timeToChangeMinutes;
    [SerializeField] private PlayerWatches _playerWatches;
    [SerializeField]  private int _minutes;
    [SerializeField] private int _hours;
    [SerializeField] private int _days;
    [SerializeField] private int _month;

    private void Start()
    {
        StartCoroutine(SpendTime());
    }

    private IEnumerator SpendTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToChangeMinutes);
            if (_minutes >= 59)
            {
                yield return new WaitForSeconds(_timeToChangeMinutes);
                ChangeHours();
                _minutes = 0;
                _playerWatches.ChangeTime(_hours, _minutes);
            }
            _minutes++;
            _playerWatches.ChangeTime(_hours, _minutes);
        }
    }

    private void ChangeHours()
    {
        if (_hours >= 23)
        {
            _hours = 0;
            _playerWatches.ChangeTime(_hours, _minutes);
            ChangeDay();
            return;
        }
        _hours++;
        _playerWatches.ChangeTime(_hours, _minutes);
    }
    
    private void ChangeDay()
    {
        if (_days >= 30)
        {
            _days = 1;
            _playerWatches.ChandeData(_days, _month);
            ChangeMonth();
            return;
        }
        _days++;
        _playerWatches.ChandeData(_days, _month);
    }
    
    private void ChangeMonth()
    {
        if (_month >= 11)
        {
            _month = 1;
            _playerWatches.ChandeData(_days, _month);
            return;
        }
        _month++;
        _playerWatches.ChandeData(_days, _month);
    }
}
