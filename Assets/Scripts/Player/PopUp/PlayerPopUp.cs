using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _popUpText;
    [SerializeField] private float _popUpTime;

    public static PlayerPopUp Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more PlayerPopUp in scene!");
        Debug.Break();
    }

    public void PopUp(string message)
    {
        StopAllCoroutines();
        StartCoroutine(PopUpping(message));
    }

    private IEnumerator PopUpping(string message)
    {
        _popUpText.text = message;
        yield return new WaitForSeconds(_popUpTime);
        _popUpText.text = "";
    }
}