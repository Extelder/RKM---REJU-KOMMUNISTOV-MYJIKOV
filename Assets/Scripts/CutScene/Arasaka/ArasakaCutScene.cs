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
    [SerializeField] private GameObject _timeCanvas;
    [SerializeField] private GameObject _yesNoCanvas;
    [SerializeField] private GameObject _guideCanvas;

    private float _lookSpeed;

    [SerializeField] private Animator _animator;

    private bool _isGuide;

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
        End();
        _isGuide = true;
    }

    public void End()
    {
        _animator.SetTrigger("End");
    }
    
    public void UnlockAchieve()
    {
        SteamAchivement.Instance.UnlockCorp();
    }

    public void CutSceneEnd()
    {
        if (_isGuide)
        {
            _timeCanvas.SetActive(true);
            _guideCanvas.SetActive(true);
            _yesNoCanvas.SetActive(false);
        }

        _guideCuteScene.SetActive(false);
        _cuteScene.SetActive(false);
        _playerCharacter.EnablePlayer();
    }
}