using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pakosti : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pakostiText;

    [SerializeField] private Day _day;

    private void OnEnable()
    {
        _day.Begined += OnBegined;
    }

    private void OnBegined()
    {
        for (int i = 0; i < _day.CurrentNumber + 1; i++)
        {
            _pakostiText.text += "\n" + Convert.ToString(_day.CompleteDay[i].DayData.Pakosty);
        }
    }

    private void OnDisable()
    {
        _day.Begined -= OnBegined;
    }
}