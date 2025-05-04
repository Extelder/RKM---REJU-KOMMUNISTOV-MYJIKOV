using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBreak : Confirmable
{
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject _breakGlass;
    [SerializeField] private GameObject _normalGlass;
    [SerializeField] private Rigidbody[] _breakedParts;
    [SerializeField] private float _breakedExplosionForce;

    [field: SerializeField] public override Transform JudgeTransform { get; protected set; }

    public event Action Confirmed;

    public override void Confirme()
    {
        Confirmed.Invoke();
        Debug.LogError("Confirmed pistol");
        _collider.enabled = false;
        _breakGlass.SetActive(true);

        for (int i = 0; i < _breakedParts.Length; i++)
        {
            _breakedParts[i].AddExplosionForce(_breakedExplosionForce, transform.position, 3);
        }

        _normalGlass.SetActive(false);
    }
}