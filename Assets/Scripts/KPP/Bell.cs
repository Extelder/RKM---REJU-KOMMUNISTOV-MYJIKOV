using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _ringAnimationTrigger = "Ring";
    [SerializeField] private CharacterSpawner _characterSpawner;

    private void OnMouseDown()
    {
        _animator.SetTrigger(_ringAnimationTrigger);
        _characterSpawner.TrySpawn();
    }
}