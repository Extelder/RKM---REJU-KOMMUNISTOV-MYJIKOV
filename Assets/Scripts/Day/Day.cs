using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct CompleteDay
{
    [field: SerializeField] public DayData DayData { get; private set; }
    [field: SerializeField] public DayEventable Eventable { get; private set; }
}

public class Day : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _seatTimeText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private AudioSource _timeEndAudio;
    [SerializeField] private GameObject _timeEndLight;

    [SerializeField] private CharacterSpawner _characterSpawner;

    [field: SerializeField] public CompleteDay[] CompleteDay { get; private set; }
    [SerializeField] private int _startHour;
    [SerializeField] private int _hourStep = 1;

    public int CurrentNumber { get; private set; }

    private int _currentHour;

    public event Action Begined;

    public static Day Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.Break();
    }

    private void Start()
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
        PlayerPrefs.SetString("Character1", "");
        PlayerPrefs.SetString("Character2", "");
        PlayerPrefs.SetString("Character3", "");
        PlayerPrefs.SetString("Character4", "");


        _currentHour = _startHour;
        _seatTimeText.text = $"{_currentHour} 00";
        _timeText.text = $"{_currentHour} 00";

        CurrentNumber = PlayerPrefs.GetInt("CurrentDay", 0);

        _characterSpawner.Bootstrap(CompleteDay[CurrentNumber].DayData.Characters);
        CompleteDay[CurrentNumber].Eventable.DayStartedEvent();

        PlayerPrefs.SetString("Spawnpoint", "Lift");
        Begined?.Invoke();
    }

    public void AddNewspaperCharacter(Character character)
    {
        if (PlayerPrefs.GetString("Character1", "") == "")
        {
            PlayerPrefs.SetString("Character1", character.Name);
            return;
        }

        if (PlayerPrefs.GetString("Character2", "") == "")
        {
            PlayerPrefs.SetString("Character2", character.Name);
            return;
        }

        if (PlayerPrefs.GetString("Character3", "") == "")
        {
            PlayerPrefs.SetString("Character3", character.Name);
            return;
        }

        if (PlayerPrefs.GetString("Character4", "") == "")
        {
            PlayerPrefs.SetString("Character4", character.Name);
            return;
        }
    }

    public void End()
    {
        PlayerPrefs.SetInt("DayEnded", 1);
        CompleteDay[CurrentNumber].Eventable.DayEndedEvent();

        _timeEndAudio.Play();
        _timeEndLight.SetActive(true);
    }
}