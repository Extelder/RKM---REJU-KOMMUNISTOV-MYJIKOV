using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EvolveGames;
using UnityEngine;

public class CaughtJarahovState : State
{
    [SerializeField] private GameObject _trueJarahov;
    [SerializeField] private PlayStopSound _playStopSound;
    [SerializeField] private AudioSource _cryAudio;
    [SerializeField] private AudioSource allertAudio;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private string _triggerName;
    [SerializeField] private float _cooldown;
    private Tween _moveTween;
    
    public override void Enter()
    {
        gameObject.SetActive(false);
        _trueJarahov.SetActive(true);
        _playStopSound.StopSound();
        CanChanged = false;
        _cryAudio.Play();
        allertAudio.Stop();
        Invoke(nameof(SetPlayerAnim), _cooldown);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void OnDisable()
    {
        _moveTween?.Kill();
    }

    private void SetPlayerAnim()
    {
        _controller.canMove = false;
        _playerAnimator.SetTrigger(_triggerName);
        _playerAnimator.SetBool("IsAnimating", true);
        Invoke(nameof(DisablePlayerAnim), _cooldown);
    }

    private void DisablePlayerAnim()
    {
        _trueJarahov.SetActive(false);
        _controller.canMove = true;
        _playerAnimator.SetBool("IsAnimating", false);
    }
}
