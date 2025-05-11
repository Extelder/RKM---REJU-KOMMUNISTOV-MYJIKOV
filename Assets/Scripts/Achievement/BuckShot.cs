using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckShot : MonoBehaviour
{
    [SerializeField] private GameObject _buckShot;

    private void OnEnable()
    {
        KPPCharacterDeathState.CharacterDead += OnCharacterDead;
    }

    private void OnCharacterDead()
    {
        _buckShot.SetActive(true);
        Destroy(this);
    }

    private void OnDisable()
    {
        KPPCharacterDeathState.CharacterDead -= OnCharacterDead;
    }
}