using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public class RunJarahovState : State
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _target;
    [SerializeField] private PlayStopSound _playStopSound;
    [SerializeField] private float _cooldown;

    private CompositeDisposable _disposable = new CompositeDisposable();


    public override void Enter()
    {
        MoveToDestination();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void MoveToDestination()
    {
        StartCoroutine(SwitchSounds());
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _navMeshAgent.SetDestination(_target.position);
        }).AddTo(_disposable);
    }

    private IEnumerator SwitchSounds()
    {
        _playStopSound.PlaySound();
        yield return new WaitForSeconds(_cooldown);
        _playStopSound.SwitchClip();
        _playStopSound.PlaySound();
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}
