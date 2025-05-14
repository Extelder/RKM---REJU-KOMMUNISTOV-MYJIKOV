using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Day : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _seatTimeText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private AudioSource _timeEndAudio;
    [SerializeField] private GameObject _timeEndLight;

    [SerializeField] private CharacterSpawner _characterSpawner;

    [SerializeField] private DayData[] _dayDatas;
    [SerializeField] private int _startHour;
    [SerializeField] private int _hourStep = 1;

    private int _currentNumber;

    private int _currentHour;

    private void Awake()
    {
        Begin();
    }

    private void OnEnable()
    {
        _characterSpawner.CharactersEnd += End;
        _characterSpawner.CharacterChanged += OnCharacterChanged;
    }

    private void OnCharacterChanged()
    {
        _currentHour += _hourStep;
        _seatTimeText.text = $"{_currentHour} 00";
        _timeText.text = $"{_currentHour} 00";
    }

    private void OnDisable()
    {
        _characterSpawner.CharactersEnd -= End;
        _characterSpawner.CharacterChanged -= OnCharacterChanged;
    }

    public void Begin()
    {
        _currentHour = _startHour;
        _seatTimeText.text = $"{_currentHour} 00";
        _timeText.text = $"{_currentHour} 00";

        _currentNumber = PlayerPrefs.GetInt("CurrentDay", 0);

        _characterSpawner.Bootstrap(_dayDatas[_currentNumber].Characters);

        PlayerPrefs.SetString("Spawnpoint", "Lift");
    }

    public void End()
    {
        _timeEndAudio.Play();
        _timeEndLight.SetActive(true);
    }
}