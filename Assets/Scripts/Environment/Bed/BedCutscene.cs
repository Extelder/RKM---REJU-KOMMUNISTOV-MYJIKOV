using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedCutscene : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _sleepAnimationBool;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("DayEnded", 0) == 1)
        {
            _animator.SetBool(_sleepAnimationBool, true);
        }
        else
        {
            PlayerCharacter.Instance.DisablePlayer();
            _animator.SetBool(_sleepAnimationBool, false);
        }
    }

    public void GetAwaken()
    {
        PlayerCharacter.Instance.EnablePlayer();
        gameObject.SetActive(false);
    }

    public void FallAsleep()
    {
        PlayerPrefs.SetInt("CurrentDay", PlayerPrefs.GetInt("CurrentDay") + 1);
        PlayerPrefs.SetInt("DayEnded", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}