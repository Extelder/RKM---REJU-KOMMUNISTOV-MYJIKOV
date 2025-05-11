using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPCharacterDeathState : State
{
    [SerializeField] private EnemyRagdollHealth _enemyRagdoll;

    public static event Action CharacterDead;

    public override void Enter()
    {
        CharacterDead?.Invoke();
        SteamAchivement.Instance?.UnlockBoom();
        _enemyRagdoll.Death();
    }
}