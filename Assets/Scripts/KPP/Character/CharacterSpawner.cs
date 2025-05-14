using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private GameObject _currentCharacter;

    private Character[] _characters;

    private bool _bootstraped;

    private int _currentCharacterIndex = -1;

    public event Action CharactersEnd;
    public event Action CharacterChanged;

    public void Bootstrap(Character[] characters)
    {
        _characters = characters;
        _bootstraped = true;
    }

    public void TrySpawn()
    {
        if (!_bootstraped)
            return;
        if (_currentCharacter != null)
            return;
        if (_currentCharacterIndex + 1 >= _characters.Length)
        {
            CharactersEnd?.Invoke();
            return;
        }

        _currentCharacter =
            Instantiate(_characterPrefab, _characterSpawnPoint.position, Quaternion.identity, transform);

        CharacterChanged?.Invoke();
        _currentCharacterIndex++;
        _currentCharacter.GetComponentInChildren<KPPCharacter>().SetCharacter(_characters[_currentCharacterIndex]);
    }
}