using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObject;
    
    public void SetActiveTrue()
    {
        for (int i = 0; i < _gameObject.Length; i++)
        {
            _gameObject[i].SetActive(true);
        }
    }

    public void SetActiveFalse()
    {
        for (int i = 0; i < _gameObject.Length; i++)
        {
            _gameObject[i].SetActive(false);
        }
    }
}
