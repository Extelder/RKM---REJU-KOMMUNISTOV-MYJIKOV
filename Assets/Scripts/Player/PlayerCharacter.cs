using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [field: SerializeField] public Transform Camera { get; private set; }

    [SerializeField] public PlayerController _controller;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject[] _model;

    [SerializeField] private GameObject _sounds;

    public static PlayerCharacter Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more PlayerCharacter in Scene");
        Debug.Break();
    }

    public void DisablePlayer()
    {
        _sounds.SetActive(false);
        _controller.enabled = false;
        _characterController.enabled = false;
        for (int i = 0; i < _model.Length; i++)
        {
            _model[i].SetActive(false);
        }
    }

    public void EnablePlayer()
    {
        GameCursor.Instance.Hide();
        _sounds.SetActive(true);
        _controller.enabled = true;
        _characterController.enabled = true;
        for (int i = 0; i < _model.Length; i++)
        {
            _model[i].SetActive(true);
        }
    }
}