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
    }
}