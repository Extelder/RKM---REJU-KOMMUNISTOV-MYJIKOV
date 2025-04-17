using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class ArasakaCutScene : MonoBehaviour
{
    [SerializeField] private CharacterController _player;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _cutScene;

    private float _lookSpeed;

    private void Start()
    {
        _lookSpeed = _playerController.lookSpeed;
        _playerController.lookSpeed = 0;
    }

    public void CutSceneEnd()
    {
        _player.enabled = true;
        _playerController.lookSpeed = _lookSpeed;
        _cutScene.SetActive(false);
    }
}