using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class ArasakaCutScene : MonoBehaviour
{
    [SerializeField] private GameObject _guideCuteScene;
    [SerializeField] private GameObject _cuteScene;

    [SerializeField] private GameObject _cutScene;
    [SerializeField] private PlayerCharacter _playerCharacter;

    private float _lookSpeed;

    [SerializeField] private Animator _animator;

    private void Start()
    {
        if (PlayerPrefs.GetInt("GuideCompleate", 0) == 1)
        {
            _cuteScene.SetActive(true);

            _guideCuteScene.SetActive(false);
        }
    }

    public void GetDefaultCameraLookSpeed()
    {
        _playerCharacter.DisablePlayer();
    }

    public void EndGuide()
    {
        _animator.SetTrigger("End");
    }

    public void CutSceneEnd()
    {
        _guideCuteScene.SetActive(false);
        _cuteScene.SetActive(false);
        _playerCharacter.EnablePlayer();
    }
}