using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using NaughtyAttributes;

public enum Casta
{
    Школьник = 1,
    Стример = 2,
    Ютубер = 3,
    Музыкант = 4
}

[CreateAssetMenu(menuName = "KPP/Character")]
public class Character : ScriptableObject
{
    public CharacterGenerator CharacterGenerator;

    public string Name;
    public Casta Casta;
    public bool _inoagent;
    public string BirthdayDate = "00.00.0000";
    public Pakost[] _pakosti;
    public News News;
    public bool HasNews => News.Text != "";

    [Button]
    public void Generate()
    {
        Name = CharacterGenerator.PoolNames[Random.Range(0, CharacterGenerator.PoolNames.Length)];
        name = Name;
        Casta = (Casta) Random.Range(1, Enum.GetNames(typeof(Casta)).Length);
        if (Random.value >= 0.7)
            _inoagent = true;
        else
            _inoagent = false;

        int randomDay = Random.Range(1, 30);
        int randomMonth = Random.Range(1, 12);
        int randomYear = Random.Range(1990, 2006);

        BirthdayDate = $"{randomDay}.{randomMonth}.{randomYear}";

        _pakosti = new Pakost[Random.Range(1, 3)];

        for (int i = 0; i < _pakosti.Length; i++)
        {
            _pakosti[i] = CharacterGenerator.PoolPakostey[Random.Range(0, CharacterGenerator.PoolPakostey.Length)];
        }
    }
}

[Serializable]
public class Pakost
{
    public string Name;
    public Color Color;
}

[Serializable]
public class News
{
    public string Title;
    public string Data = "00.00";
    public string Text;
    public Color TitleColor;
    public Color TextColor;
    public Sprite Image;
}