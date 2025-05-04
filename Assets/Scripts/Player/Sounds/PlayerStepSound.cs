using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStepSound : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AudioSource _stepSound;
    [SerializeField] private AudioClip _officeStepSound;
    [SerializeField] private AudioClip _defaultStepSound;
    [SerializeField] private int _officeSceneIndex;
    [SerializeField] private int _secondFloorOfficeSceneIndex;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == _officeSceneIndex ||
            SceneManager.GetActiveScene().buildIndex == _secondFloorOfficeSceneIndex)
        {
            _stepSound.clip = _officeStepSound;
        }
        else
        {
            _stepSound.clip = _defaultStepSound;
        }

        _playerController.Moving.Subscribe(_ =>
        {
            if (_)
            {
                _stepSound.loop = true;
                _stepSound.Play();
            }
            else
            {
                _stepSound.loop = false;
                if (!_stepSound.isPlaying)
                {
                    _stepSound.Stop();
                }
            }
        }).AddTo(_compositeDisposable);
    }

    private void OnDisable()
    {
        _compositeDisposable.Clear();
        _stepSound.Stop();
    }
}