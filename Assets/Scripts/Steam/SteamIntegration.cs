using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Steamworks.Data;
using UnityEngine;

public class SteamIntegration : MonoBehaviour
{
    private void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(3732390);
            DontDestroyOnLoad(gameObject);
            Debug.LogError(Steamworks.SteamClient.Name);
        }
        catch (Exception e)
        {
            Debug.LogError("Steam exception " + e);
        }
    }

    public bool IsThisAchievementUnlocked(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        return ach.State;
    }

    public void UnlockAchievement(string id)
    {
        bool z = IsThisAchievementUnlocked(id);

        if (!z)
        {
            new Steamworks.Data.Achievement(id).Trigger();
        }
    }

    public void ClearAchivement(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        ach.Clear();
    }

    private void Update()
    {
        Steamworks.SteamClient.RunCallbacks();
    }

    private void OnDisable()
    {
        Steamworks.SteamClient.Shutdown();
    }

    private void OnApplicationQuit()
    {
        Steamworks.SteamClient.Shutdown();
    }
}