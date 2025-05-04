using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Passport : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _birthday;
    [SerializeField] private TextMeshProUGUI _sex;

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
    }
}