using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnTriggerEnterExit : MonoBehaviour
{
    [SerializeField] private GameObject _videoPlayers;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacter>(out PlayerCharacter _character))
        {
            _videoPlayers.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacter>(out PlayerCharacter _character))
        {
            _videoPlayers.SetActive(false);
        }
    }
}
