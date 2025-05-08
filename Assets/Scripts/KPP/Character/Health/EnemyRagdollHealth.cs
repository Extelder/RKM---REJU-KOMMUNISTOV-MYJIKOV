using System;
using System.Collections;
using System.Collections.Generic;
using NTC.Global.System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRagdollHealth : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private float _explosionForce = 100;
    [SerializeField] private Transform _ragdollParent;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Transform _headBone;
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private RagdollOperations _ragdollOperations;

    [SerializeField] private GameObject _character;

    private void Start()
    {
        _character = GameObject.FindObjectOfType<KPPShotgun>().gameObject;
    }

    public void Death()
    {
        Death(_character.transform, _explosionForce);
    }

    public void Death(Transform explosionPoint, float force)
    {
        _ragdollParent.parent = null;
        _ragdollParent.SetParent(null);

        _enemyAnimator.enabled = false;
        _ragdollOperations.EnableRagdoll();

        int rand = Random.Range(0, 20);
        var headChance = rand >= 17;
        if (headChance)
        {
            _headBone.transform.localScale = Vector3.zero;
            _head.SetActive(true);
        }

        _ragdollOperations.AddExplosionForce(force, explosionPoint.position, 20, 1,
            ForceMode.Impulse);


        _skinnedMeshRenderer.updateWhenOffscreen = true;

        Destroy(_enemyParent);
        Destroy(gameObject);
    }
}