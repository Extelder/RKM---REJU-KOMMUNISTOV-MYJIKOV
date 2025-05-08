using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPCharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _walkAnimationBoolName;
    [SerializeField] private string _givePapersTriggerName;
    [SerializeField] private string _takePapersTriggerName;

    public event Action PaperGeted;
    public event Action PaperGived;
    public event Action PaperTaked;

    public void Idle()
    {
        DisableAllBool();
    }

    public void Walk()
    {
        DisableAllBool();
        _animator.SetBool(_walkAnimationBoolName, true);
    }

    public void GivePapers()
    {
        DisableAllBool();
        _animator.SetTrigger(_givePapersTriggerName);
    }

    public void TakePapers()
    {
        DisableAllBool();
        _animator.SetTrigger(_takePapersTriggerName);
    }

    public void GetPaperAnimationEvent()
    {
        PaperGeted?.Invoke();
    }

    public void GivePapersAnimationEvent()
    {
        PaperGived?.Invoke();
    }

    public void TakePapersAnimationEvent()
    {
        PaperTaked?.Invoke();
    }

    public void DisableAllBool()
    {
        _animator.SetBool(_walkAnimationBoolName, false);
        _animator.ResetTrigger(_givePapersTriggerName);
        _animator.ResetTrigger(_takePapersTriggerName);
    }
}