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
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == _officeSceneIndex)
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
                _stepSound.Play();
            }
            else
            {
                _stepSound.Stop();
            }
        }).AddTo(_compositeDisposable);
    }

    private void OnDisable()
    {
        _compositeDisposable.Clear();
        _stepSound.Stop();
    }
}