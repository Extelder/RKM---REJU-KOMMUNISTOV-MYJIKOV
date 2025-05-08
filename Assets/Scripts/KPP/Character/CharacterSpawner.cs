using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private GameObject _currentCharacter;

    public void TrySpawn()
    {
        if (_currentCharacter != null)
            return;
        _currentCharacter =
            Instantiate(_characterPrefab, _characterSpawnPoint.position, Quaternion.identity, transform);
    }
}