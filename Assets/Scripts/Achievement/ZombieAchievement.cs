using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class ZombieAchievement : MonoBehaviour
{
    [SerializeField] private float _timeToWait;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController PlayerController))
        {
            StartCoroutine(WaitingForUnlock());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController PlayerController))
        {
            StopAllCoroutines();
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator WaitingForUnlock()
    {
        yield return new WaitForSeconds(_timeToWait);
        SteamAchivement.Instance.UnlockZomb();
        Destroy(this);
    }
}