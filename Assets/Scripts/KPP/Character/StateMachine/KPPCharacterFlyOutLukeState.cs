using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KPPCharacterFlyOutLukeState : State
{
    [SerializeField] private KPPCharacterMove _characterMove;
    [SerializeField] private GameObject _parent;
    [SerializeField] private Transform _flyPoint;
    [SerializeField] private float _flyTime;
    [SerializeField] private Ease _ease = Ease.Flash;

    public override void Enter()
    {
        _characterMove.Move(_flyPoint, _flyTime, () => { Destroy(_parent); }, _ease);
    }
}