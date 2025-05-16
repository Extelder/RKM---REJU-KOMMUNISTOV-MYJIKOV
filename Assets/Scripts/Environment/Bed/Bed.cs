using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private string _notTimeToSleepPopUp = "Рабочий день не закончен";

    private void Start()
    {
        if (PlayerPrefs.GetString("Spawnpoint") == "Bed")
        {
            _camera.SetActive(true);
        }
    }

    public void Interact()
    {
        if (PlayerPrefs.GetInt("DayEnded", 0) == 1)
        {
            PlayerPrefs.SetString("Spawnpoint", "Bed");
            PlayerCharacter.Instance.DisablePlayer();
            _camera.SetActive(true);
            return;
        }

        PlayerPopUp.Instance.PopUp(_notTimeToSleepPopUp);
    }
}