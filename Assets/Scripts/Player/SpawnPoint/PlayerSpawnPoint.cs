using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _defaultPoint;
    [SerializeField] private Transform _liftPoint;
    [SerializeField] private Transform _bedPoint;

    private Transform _currentSpawnPoint;

    private void Start()
    {
        switch (PlayerPrefs.GetString("Spawnpoint", "Default"))
        {
            case "Lift":
                _currentSpawnPoint = _liftPoint;
                break;
            case "Bed":
                _currentSpawnPoint = _bedPoint;
                break;
            default:
                _currentSpawnPoint = _defaultPoint;
                break;
        }

        _player.position = _currentSpawnPoint.position;
        _player.rotation = _currentSpawnPoint.rotation;
    }
}