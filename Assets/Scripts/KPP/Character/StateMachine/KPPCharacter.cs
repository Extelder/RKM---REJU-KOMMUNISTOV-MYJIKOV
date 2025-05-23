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
    public event Action Pass;

    public void SetCharacter(Character character)
    {
        Character = character;
    }

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
        Day.Instance.AddNewspaperCharacter(Character);

        Dead?.Invoke();
        _kppCharacterStateMachine.Dead();
    }

    public void OnBan()
    {
        Day.Instance.AddNewspaperCharacter(Character);
        Dead?.Invoke();
        _kppCharacterStateMachine.FlyToLuke();
    }

    public void OnPass()
    {
        _kppCharacterStateMachine.GoHome();
        Pass?.Invoke();
    }
}