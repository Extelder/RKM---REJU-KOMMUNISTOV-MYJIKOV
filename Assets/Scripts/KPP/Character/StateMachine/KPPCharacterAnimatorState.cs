using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KPPCharacterAnimatorState : State
{
    [field: SerializeField] public KPPCharacterAnimator Animator { get; private set; }

    public abstract override void Enter();
}
