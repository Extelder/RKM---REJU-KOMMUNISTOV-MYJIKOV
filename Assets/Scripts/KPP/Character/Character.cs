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
    Музыкант = 4,
    Безработный = 5,
    Наркоман = 6,
    Киллер = 7,
    Секс_Инструктор = 8,
    Инфоцыган = 9,
    Адун = 10
}

public enum Sex
{
    Муж = 1,
    Жен = 2,
    Гидроцефал = 3,
    Оно = 4,
    Буцефал = 5,
    Рапич = 6
}

public enum PakostiType
{
    ПропагандаНаркотиков,
    Тату,
    ЛГБТ,
    АНТИВОЕННЫЕДЕЙСТВИЯ,
    КАЗИНО,
    ТУПОСТЬ,
    ИБОНЕХУЙ
}

[CreateAssetMenu(menuName = "KPP/Character")]
public class Character : ScriptableObject
{
    public CharacterGenerator CharacterGenerator;

    public string Name;
    public Casta Casta;
    public Sex Sex;
    public bool Inoagent;
    public string BirthdayDate = "00.00.0000";
    public Pakost[] Pakosti;
    public News News;
    public bool HasNews => News.Text != "";

    [Button]
    public void Generate()
    {
        Name = CharacterGenerator.PoolNames[Random.Range(0, CharacterGenerator.PoolNames.Length)];
        name = Name;
        Casta = (Casta) Random.Range(1, Enum.GetNames(typeof(Casta)).Length);
        Sex = (Sex) Random.Range(1, Enum.GetNames(typeof(Sex)).Length - 1);
        if (Random.value >= 0.7)
            Inoagent = true;
        else
            Inoagent = false;

        int randomDay = Random.Range(1, 30);
        int randomMonth = Random.Range(1, 12);
        int randomYear = Random.Range(1990, 2006);

        BirthdayDate = $"{randomDay}.{randomMonth}.{randomYear}";

        Pakosti = new Pakost[Random.Range(1, Pakosti.Length)];

        for (int i = 0; i < Pakosti.Length; i++)
        {
            var pakost = CharacterGenerator.PoolPakostey[Random.Range(0, CharacterGenerator.PoolPakostey.Length)];
            for (int j = 0; j < Pakosti.Length; j++)
            {
                if (pakost != Pakosti[j])
                {
                    Pakosti[i] = pakost;
                }
            }
            
        }
    }
}

[Serializable]
public class Pakost
{
    public PakostiType PakostiType;           
    public string Name;
    public Color Color;
}

[Serializable]
public class News
{
    public string Title;
    public string Text;
    public Color TitleColor;
    public Color TextColor;
    public Sprite Image;
}