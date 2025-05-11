using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Passport : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _birthday;
    [SerializeField] private TextMeshProUGUI _sex;
    [SerializeField] private TextMeshProUGUI _pakosti;
    [SerializeField] private TextMeshProUGUI _casta;
    [SerializeField] private GameObject _inoagentImage;

    private void Start()
    {
        Bootstrap();
    }

    private void Bootstrap()
    {
        _character.Generate();
        _name.text = _character.Name;
        _birthday.text = _character.BirthdayDate;
        _sex.text = _character.Sex.ToString();
        _pakosti.text = _character.Pakosti.ToString();
        _casta.text = _character.Casta.ToString();
        if (_character.Inoagent)
        {
            _inoagentImage.SetActive(true);
        }
        else
        {
            _inoagentImage.SetActive(false);
        }
    }
}