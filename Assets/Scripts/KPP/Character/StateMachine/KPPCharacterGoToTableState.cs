using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPCharacterGoToTableState : KPPCharacterAnimatorState
{
    [SerializeField] private KPPCharacterMove _characterMove;
    [SerializeField] private KPPCharacterStateMachine _characterStateMachine;
    [SerializeField] private Transform _tablePoint;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _rotateDuration;

    public override void Enter()
    {
        Animator.Walk();
        _characterMove.Move(_tablePoint, _moveDuration,
            () =>
            {
                Animator.Idle();
                _characterMove.Rotate(_tablePoint.eulerAngles, _rotateDuration,
                    () => { _characterStateMachine.GivePapers(); });
            });
    }
}