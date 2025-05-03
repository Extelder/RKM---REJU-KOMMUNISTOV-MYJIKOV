using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBoolTrigger : MonoBehaviour
{
    [SerializeField] private string _boolName;
    [SerializeField] private Animator[] _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacter>(out PlayerCharacter _playerCharacter))
        {
            for (int i = 0; i < _animator.Length; i++)
            {
                _animator[i].SetBool(_boolName,true);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacter>(out PlayerCharacter _playerCharacter))
        {
            for (int i = 0; i < _animator.Length; i++)
            {
                _animator[i].SetBool(_boolName,false);
            }
        }
    }
}
