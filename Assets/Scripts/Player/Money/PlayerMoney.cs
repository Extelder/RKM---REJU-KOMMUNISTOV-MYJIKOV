using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int CurrentMoney { get; private set; }

    public static PlayerMoney Instance { get; private set; }

    public event Action<int> MoneyValueChanged;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more PlayerMoney");
        Debug.Break();
    }

    private void Start()
    {
        CurrentMoney = PlayerPrefs.GetInt("Money", 232);
        ValueChanged();
    }

    public void SpentMoney(int value)
    {
        CurrentMoney -= value;
        ValueChanged();
    }

    private void ValueChanged()
    {
        PlayerPrefs.SetInt("Money", CurrentMoney);
        MoneyValueChanged?.Invoke(CurrentMoney);
    }

    public void EarnMoney(int value)
    {
        CurrentMoney += value;
        ValueChanged();
    }
}