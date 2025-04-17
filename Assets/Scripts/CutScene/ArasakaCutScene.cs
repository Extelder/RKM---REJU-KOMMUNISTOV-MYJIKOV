using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class ArasakaCutScene : MonoBehaviour
{
    [SerializeField] private GameObject _guideCuteScene;
    [SerializeField] private GameObject _cuteScene;

    [SerializeField] private CharacterController _player;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _cutScene;

    private float _lookSpeed;

    [SerializeField] private Animator _animator;

    private void Start()
    {
        if (PlayerPrefs.GetInt("GuideCompleate", 0) == 1)
        {
            _cuteScene.SetActive(true);

            _guideCuteScene.SetActive(false);
        }

        _lookSpeed = _playerController.lookSpeed;
        _playerController.lookSpeed = 0;
    }
    
    public void EndGuide()
    {
        _animator.SetTrigger("End");
    }
    
    public void CutSceneEnd()
    {
        _player.enabled = true;
        _playerController.lookSpeed = _lookSpeed;
        _cutScene.SetActive(false);
    }
}