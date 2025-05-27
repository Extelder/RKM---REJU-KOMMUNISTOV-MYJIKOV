using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


public enum LocalizeType
{
    Ru,
    Eng
}

public class Localization : MonoBehaviour
{
    [field: SerializeField]
    public ReactiveProperty<LocalizeType> CurrentLocalizeType { get; private set; } =
        new ReactiveProperty<LocalizeType>();

    public static Localization Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }
}