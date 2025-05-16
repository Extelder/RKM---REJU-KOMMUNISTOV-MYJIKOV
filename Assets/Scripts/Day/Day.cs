using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct CompleteDay
{
    [field: SerializeField] public DayData DayData{ get; private set; }
    [field: SerializeField] public DayEventable Eventable { get; private set; }
}

public class Day : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _seatTimeText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private AudioSource _timeEndAudio;
    [SerializeField] private GameObject _timeEndLight;

    [SerializeField] private CharacterSpawner _characterSpawner;

    [SerializeField] private CompleteDay[] _completeDay;
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
        _completeDay[_currentNumber].Eventable.DayStartedEvent();
        _currentHour = _startHour;
        _seatTimeText.text = $"{_currentHour} 00";
        _timeText.text = $"{_currentHour} 00";

        _currentNumber = PlayerPrefs.GetInt("CurrentDay", 0);

        _characterSpawner.Bootstrap(_completeDay[_currentNumber].DayData.Characters);

        PlayerPrefs.SetString("Spawnpoint", "Lift");
    }

    public void End()
    {
        _completeDay[_currentNumber].Eventable.DayEndedEvent();
        _timeEndAudio.Play();
        _timeEndLight.SetActive(true);
    }
}