using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrigger : MonoBehaviour
{
    [SerializeField] private string _triggerName;
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacter>(out PlayerCharacter _playerCharacter))
        {
            _animator.SetTrigger(_triggerName);
        }
    }
}
