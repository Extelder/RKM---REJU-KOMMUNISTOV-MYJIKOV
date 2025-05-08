using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KPPCharacter : MonoBehaviour
{
    [SerializeField] private PlayerDragAndDrop _playerDragAndDrop;
    [SerializeField] private KPPCharacterStateMachine _kppCharacterStateMachine;
    [SerializeField] private LookAtConstraint _lookAtConstraint;

    [field: SerializeField] public Character Character { get; private set; }

    public event Action Dead;

    private void Start()
    {
        if (PlayerDragAndDrop.Instance != null)
        {
            PlayerDragAndDrop.Instance.Character = this;
            _lookAtConstraint.SetSource(0, new ConstraintSource
            {
                sourceTransform = PlayerDragAndDrop.Instance.Camera.transform,
                weight = 1f
            });
        }
        else
        {
            _playerDragAndDrop.Character = this;
        }
    }

    public void OnShoot()
    {
        Dead?.Invoke();
        _kppCharacterStateMachine.Dead();
    }

    public void OnBan()
    {
        Dead?.Invoke();
        _kppCharacterStateMachine.FlyToLuke();
    }

    public void OnPass()
    {
        _kppCharacterStateMachine.GoHome();
    }
}