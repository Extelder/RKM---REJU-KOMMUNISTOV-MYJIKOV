using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerController _player;

    private void Update()
    {
        _animator.SetBool("IsWalking", _player.Moving);
        if (_player.horizontal == 0)
        {
            _animator.SetBool("IsWalkingLeft", false);
            _animator.SetBool("IsWalkingRight", false);
            return;
        }

        if (_player.horizontal < 0)
        {
            _animator.SetBool("IsWalkingLeft", _player.Moving);
        }
        
        if (_player.horizontal > 0)
        {
            _animator.SetBool("IsWalkingRight", _player.Moving);
        }
    }
}