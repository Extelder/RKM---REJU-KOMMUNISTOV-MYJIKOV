using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPCharacterDeathState : State
{
    [SerializeField] private EnemyRagdollHealth _enemyRagdoll;

    public override void Enter()
    {
        _enemyRagdoll.Death();
    }
}