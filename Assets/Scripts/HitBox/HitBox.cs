using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private Health _health;

    public virtual void Hit(float damage)
    {
        _health.TakeDamage(damage);
    }
}
