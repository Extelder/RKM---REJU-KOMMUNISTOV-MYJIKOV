using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

[Serializable]
public struct LocalizationText
{
    public LocalizeType LocalizeType;
    [TextAreaAttribute] public string Text;
}

public class TMPLocalaze : MonoBehaviour
{
    [SerializeField] private LocalizationText[] _localizationText;
    [SerializeField] private TextMeshProUGUI _text;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
    {
        Localization.Instance.CurrentLocalizeType.Subscribe(_ => { UpdateText(); }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }

    public void UpdateText()
    {
        for (int i = 0; i < _localizationText.Length; i++)
        {
            if (_localizationText[i].LocalizeType == Localization.Instance.CurrentLocalizeType.Value)
            {
                _text.text = _localizationText[i].Text;
            }
        }
    }

    private void Awake()
    {
        UpdateText();
    }
}