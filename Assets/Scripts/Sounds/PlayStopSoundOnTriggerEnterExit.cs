using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class PlayStopSoundOnTriggerEnterExit : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            _source.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            _source.Stop();
        }
    }
}