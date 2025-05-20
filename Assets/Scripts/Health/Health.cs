using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    private float _currentValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        float health = _currentValue - damage;
        if (health > 0)
        {
            ChangeHealthValue(health);
            return;
        }
        Death();
    }

    public abstract void Death();

    private void ChangeHealthValue(float value)
    {
        if (_currentValue > 0)
        {
            _currentValue = value;
        }
    }
}
