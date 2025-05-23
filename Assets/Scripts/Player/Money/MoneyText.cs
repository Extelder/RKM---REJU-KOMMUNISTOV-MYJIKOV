using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        PlayerMoney.Instance.MoneyValueChanged += OnMoneyValueChanged;
        OnMoneyValueChanged(PlayerMoney.Instance.CurrentMoney);
    }

    private void OnMoneyValueChanged(int value)
    {
        _text.text = value.ToString() + "$";
    }

    private void OnDisable()
    {
        PlayerMoney.Instance.MoneyValueChanged -= OnMoneyValueChanged;
    }
}