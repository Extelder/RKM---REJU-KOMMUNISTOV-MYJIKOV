using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class SetActiveTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerCharacter))
        {
            _gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerCharacter))
        {
            _gameObject.SetActive(false);
        }
    }
}
