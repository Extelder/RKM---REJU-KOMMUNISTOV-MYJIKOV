using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPCharacterStateMachine : StateMachine
{
    [SerializeField] private State _goToTableState;
    [SerializeField] private State _givePapersState;
    [SerializeField] private State _goHomeState;
    [SerializeField] private State _FlyToLukeState;
    [SerializeField] private State _deadState;

    private void Start()
    {
        GoToTable();
    }

    public void GoToTable()
    {
        ChangeState(_goToTableState);
    }

    public void GivePapers()
    {
        ChangeState(_givePapersState);
    }

    public void GoHome()
    {
        ChangeState(_goHomeState);
    }

    public void FlyToLuke()
    {
        if (CurrentState == _goHomeState)
            return;
        ChangeState(_FlyToLukeState);
    }

    public void Dead()
    {
        ChangeState(_deadState);
    }
}