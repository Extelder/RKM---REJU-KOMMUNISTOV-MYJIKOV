using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UniRx;
using UnityEngine;

public class PlayerStepSound : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AudioSource _stepSound;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    private void OnEnable()
    {
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
    }
}