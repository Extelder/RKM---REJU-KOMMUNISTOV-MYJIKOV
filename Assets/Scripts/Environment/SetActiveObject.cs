using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObject : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    
    public void SetActiveTrue()
    {
        _gameObject.SetActive(true);
    }

    public void SetActiveFalse()
    {
        _gameObject.SetActive(false);
    }
}
