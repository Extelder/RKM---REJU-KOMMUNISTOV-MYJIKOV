using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Newspaper : MonoBehaviour
{
    [SerializeField] private Character[] _character;
    [SerializeField] private NewsContainer[] _newsContainer;
    [SerializeField] private TextMeshProUGUI _date;
    private List<Character> _newsCharacters = new List<Character>();

    private void Start()
    {
        CheckNews();
        Show();
    }

    public void CheckNews()
    {
        for (int i = 0; i < _character.Length; i++)
        {
            if (_character[i].HasNews)
            {
                _newsCharacters.Add(_character[i]);
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
            _newsContainer[i].TitleText.text = _character[i].News.Title;
            _newsContainer[i].MainText.text = _character[i].News.Text;
            _date.text = _character[i].News.Data;
            _newsContainer[i].TitleText.color = _character[i].News.TitleColor;
            _newsContainer[i].MainText.color = _character[i].News.TextColor;
            _newsContainer[i].Image.sprite = _character[i].News.Image;
        }
    }
}
