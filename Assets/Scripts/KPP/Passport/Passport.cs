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
    [SerializeField] private TextMeshProUGUI[] _pakosti;
    [SerializeField] private TextMeshProUGUI _casta;
    [SerializeField] private GameObject _inoagentImage;

    private void OnEnable()
    {
        if (Localization.Instance.CurrentLocalizeType.Value == LocalizeType.Ru)
            Bootstrap();
        else
            BootstrapEng();
    }

    private void BootstrapEng()
    {
        _character = PlayerDragAndDrop.Instance.Character.Character;

        _name.text = _character.NameEng;
        _birthday.text = _character.BirthdayDate;
        _sex.text = _character.SexEng.ToString();
        for (int i = 0; i < _character.PakostiEng.Length; i++)
        {
            if (i > _character.PakostiEng.Length)
            {
                _pakosti[i].text = String.Empty;
                _pakosti[i].color = Color.white;
            }

            _pakosti[i].text = _character.PakostiEng[i].Name;
            _pakosti[i].color = _character.PakostiEng[i].Color;
        }

        _casta.text = _character.CastaEng.ToString();
        if (_character.Inoagent)
        {
            _inoagentImage.SetActive(true);
        }
        else
        {
            _inoagentImage.SetActive(false);
        }
    }
    
    private void Bootstrap()
    {
        _character = PlayerDragAndDrop.Instance.Character.Character;

        _name.text = _character.Name;
        _birthday.text = _character.BirthdayDate;
        _sex.text = _character.Sex.ToString();
        for (int i = 0; i < _character.Pakosti.Length; i++)
        {
            if (i > _character.Pakosti.Length)
            {
                _pakosti[i].text = String.Empty;
                _pakosti[i].color = Color.white;
            }

            _pakosti[i].text = _character.Pakosti[i].Name;
            _pakosti[i].color = _character.Pakosti[i].Color;
        }

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

    private void OnDisable()
    {
        for (int i = 0; i < _pakosti.Length; i++)
        {
            _pakosti[i].text = String.Empty;
            _pakosti[i].color = Color.white;
        }
    }
}