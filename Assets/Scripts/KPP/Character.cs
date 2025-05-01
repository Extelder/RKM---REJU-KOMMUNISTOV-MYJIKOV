using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Casta
{
    Школьник,
    Стример,
    Ютубер,
}

[CreateAssetMenu(menuName = "KPP/Character")]
public class Character : ScriptableObject
{
    public string Name;
    public Casta Casta;
    public bool _inoagent;
    public string BirthdayDate = "00.00.0000";
    public Pakost[] _pakosti;
    public News News;
    public bool HasNews => News.Text != "";
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