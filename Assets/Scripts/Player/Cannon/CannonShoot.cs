using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _ignoreLayer;

    [SerializeField] private KeyCode _attackKey;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _shootBoolName;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private PlayerSeatPlace _playerSeatPlace;
    [SerializeField] private ParticleSystem _shootParticle;

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_camera.position, _camera.forward * _attackRange);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_attackKey) && !_playerSeatPlace.CanUseThirdPerson)
        {
            _animator.SetBool(_shootBoolName, true);
        }
    }

    public void PerformAttack()
    {
        _shootSound.Play();
        _shootParticle.Play();
        if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, _attackRange, ~_ignoreLayer))
        {
            if (hit.collider.TryGetComponent<HitBox>(out HitBox hitBox))
            {
                hitBox.Hit(_damage);
            }
        }
    }

    public void ShootAnimationEnd()
    {
        _animator.SetBool(_shootBoolName, false);
    }
}
