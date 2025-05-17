using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Newspaper : MonoBehaviour
{
    [SerializeField] private Character[] _character;
    [SerializeField] private NewsContainer[] _newsContainer;
    [SerializeField] private TextMeshProUGUI _date;
    private List<Character> _newsCharacters = new List<Character>();

    [SerializeField] private Character[] _currentCharacters;

    private List<Character> _newCharacters;


    private void Start()
    {
        _newCharacters = new List<Character>();

        for (int i = 0; i < _character.Length; i++)
        {
            if (PlayerPrefs.GetString("Character1", "") == _character[i].Name)
            {
                _newCharacters.Add(_character[i]);
                break;
            }
        }

        for (int i = 0; i < _character.Length; i++)
        {
            if (PlayerPrefs.GetString("Character2", "") == _character[i].Name)
            {
                _newCharacters.Add(_character[i]);
            }
        }

        for (int i = 0; i < _character.Length; i++)
        {
            if (PlayerPrefs.GetString("Character3", "") == _character[i].Name)
            {
                _newCharacters.Add(_character[i]);
            }
        }

        for (int i = 0; i < _character.Length; i++)
        {
            if (PlayerPrefs.GetString("Character4", "") == _character[i].Name)
            {
                _newCharacters.Add(_character[i]);
            }
        }


        CheckNews();
        Show();
    }

    public void CheckNews()
    {
        _currentCharacters = _newCharacters.ToArray();

        for (int i = 0; i < _currentCharacters.Length; i++)
        {
            if (_currentCharacters[i] == null)
                continue;
            if (_currentCharacters[i].HasNews)
            {
                _newsCharacters.Add(_currentCharacters[i]);
            }
        }
    }

    private void Show()
    {
        for (int i = 0; i < _newsCharacters.ToArray().Length; i++)
        {
            if (_newsCharacters == null)
            {
                continue;
            }


            _newsContainer[i].TitleText.gameObject.SetActive(true);
            _newsContainer[i].MainText.gameObject.SetActive(true);
            _newsContainer[i].Image.gameObject.SetActive(true);
            _date.gameObject.SetActive(true);

            _newsContainer[i].TitleText.text = _currentCharacters[i].News.Title;
            _newsContainer[i].MainText.text = _currentCharacters[i].News.Text;
            _date.text = _currentCharacters[i].News.Data;
            _newsContainer[i].TitleText.color = _currentCharacters[i].News.TitleColor;
            _newsContainer[i].MainText.color = _currentCharacters[i].News.TextColor;
            _newsContainer[i].Image.sprite = _currentCharacters[i].News.Image;
        }
    }
}