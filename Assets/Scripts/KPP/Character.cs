using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

[Serializable]
public class Pakost
{
    public string Name;
    public Color Color;
}