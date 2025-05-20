using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public void DestroyGameObject()
    {
        Destroy(_gameObject);
    }
}
