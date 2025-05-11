using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SteamAchivement : MonoBehaviour
{
    [SerializeField] private SteamIntegration _steam;
    [SerializeField] private string _pissAVName = "PISSAV";
    [SerializeField] private string _corpAVName = "CORPAV";
    [SerializeField] private string _zombAVName = "ZOMBAV";
    [SerializeField] private string _fuhAVName = "FUHAV";
    [SerializeField] private string _boomAVName = "BOOMAV";
    [SerializeField] private string _superAVName = "SUPERAV";
    [SerializeField] private string _lukeAVName = "LUKEAV";

    public static SteamAchivement Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more SteamAchivement in Scene!");
        Debug.Break();
    }


    [Button]
    public void UnlockPiss()
    {
        _steam.UnlockAchievement(_pissAVName);
    }

    public void UnlockLuke()
    {
        _steam.UnlockAchievement(_lukeAVName);
    }

    public void UnlockCorp()
    {
        _steam.UnlockAchievement(_corpAVName);
    }

    public void UnlockZomb()
    {
        _steam.UnlockAchievement(_zombAVName);
    }

    public void UnlockFuh()
    {
        _steam.UnlockAchievement(_fuhAVName);
    }

    public void UnlockBoom()
    {
        _steam.UnlockAchievement(_boomAVName);
    }

    public void UnlockSuperman()
    {
        _steam.UnlockAchievement(_superAVName);
    }

    [Button]
    public void ClearAll()
    {
        _steam.ClearAchivement(_pissAVName);
        _steam.ClearAchivement(_corpAVName);
        _steam.ClearAchivement(_zombAVName);
        _steam.ClearAchivement(_fuhAVName);
        _steam.ClearAchivement(_boomAVName);
        _steam.ClearAchivement(_superAVName);
        _steam.ClearAchivement(_lukeAVName);
    }
}