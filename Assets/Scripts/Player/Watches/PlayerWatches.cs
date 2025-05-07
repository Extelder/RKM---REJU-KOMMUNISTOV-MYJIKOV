using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWatches : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _dataText;

    public void ChangeTime(int hours, int minutes)
    {
        string time = hours.ToString("00") + " " + minutes.ToString("00");
        _timeText.text = time;
    }

    public void ChandeData(int day, int month)
    {
        string data = day.ToString("00") + "." + month.ToString("00");
        _dataText.text = data;
    }
}
