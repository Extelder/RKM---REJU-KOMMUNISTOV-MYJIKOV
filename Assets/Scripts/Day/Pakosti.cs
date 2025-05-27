using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pakosti : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pakostiText;
    [SerializeField] private CharacterSpawner _spawner;
    [SerializeField] private int _penaltyValue;

    [SerializeField] private Day _day;

    public List<PakostiType> PakostiType { get; private set; } = new List<PakostiType>();

    private void OnEnable()
    {
        _day.Begined += OnBegined;
        _spawner.CharacterChanged += OnCharacterChanged;
    }

    private void OnCharacterChanged()
    {
        _spawner.CurrentKPPCharacter.Dead += OnCharacterDead;
        _spawner.CurrentKPPCharacter.Pass += OnCharacterPass;
    }

    private void OnCharacterPass()
    {
        _spawner.CurrentKPPCharacter.Pass -= OnCharacterPass;
        _spawner.CurrentKPPCharacter.Dead -= OnCharacterDead;

        for (int i = 0; i < _spawner.CurrentKPPCharacter.Character.Pakosti.Length; i++)
        {
            for (int j = 0; j < PakostiType.ToArray().Length; j++)
            {
                if (_spawner.CurrentKPPCharacter.Character.Pakosti[i].PakostiType == PakostiType[j])
                {
                    Penalty();
                    return;
                }
            }
        }
    }

    private void OnCharacterDead()
    {
        _spawner.CurrentKPPCharacter.Pass -= OnCharacterPass;
        _spawner.CurrentKPPCharacter.Dead -= OnCharacterDead;

        for (int i = 0; i < _spawner.CurrentKPPCharacter.Character.Pakosti.Length; i++)
        {
            for (int j = 0; j < PakostiType.ToArray().Length; j++)
            {
                if (_spawner.CurrentKPPCharacter.Character.Pakosti[i].PakostiType == PakostiType[j])
                {
                    return;
                }
            }
        }

        Penalty();
    }

    private void Penalty()
    {
        PlayerMoney.Instance.SpentMoney(_penaltyValue);
    }

    private void OnBegined()
    {
        for (int i = 0; i < _day.CurrentNumber + 1; i++)
        {
            PakostiType.Add(_day.CompleteDay[i].DayData.Pakosty);
            if (Localization.Instance.CurrentLocalizeType.Value == LocalizeType.Ru)
                _pakostiText.text += "\n" + Convert.ToString(_day.CompleteDay[i].DayData.Pakosty);
            else
                _pakostiText.text += "\n" + Convert.ToString(_day.CompleteDay[i].DayData.PakostyEng);
        }
    }

    private void OnDisable()
    {
        _day.Begined -= OnBegined;
        _spawner.CharacterChanged -= OnCharacterChanged;
        _spawner.CurrentKPPCharacter.Pass -= OnCharacterPass;
        _spawner.CurrentKPPCharacter.Dead -= OnCharacterDead;
    }
}