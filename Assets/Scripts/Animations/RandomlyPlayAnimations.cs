using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomlyPlayAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _minCoolDown;
    [SerializeField] private int _maxCoolDown;
    [SerializeField] private string _intName;

    private void Start()
    {
        StartCoroutine(RandomizeAnimations());
    }

    private IEnumerator RandomizeAnimations()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minCoolDown, _maxCoolDown));
            _animator.SetInteger(_intName ,Random.Range(1, 4));
        }
    }
}
