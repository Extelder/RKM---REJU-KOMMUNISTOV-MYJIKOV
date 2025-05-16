using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarahovStateMachine : StateMachine
{
    [SerializeField] private State _runJarahovState;
    [SerializeField] private State _caughtJarahovState;
    
    public void Run()
    {
        ChangeState(_runJarahovState);
    }

    public void Caught()
    {
        ChangeState(_caughtJarahovState);
    }
}
