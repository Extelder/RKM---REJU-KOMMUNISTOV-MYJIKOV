using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarahovInteractable : MonoBehaviour, Iinteractable
{
    [SerializeField] private JarahovStateMachine _jarahovStateMachine;
    public void Interact()
    {
        _jarahovStateMachine.Caught();
    }
}
