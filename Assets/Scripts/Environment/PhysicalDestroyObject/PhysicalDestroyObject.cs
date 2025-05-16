using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalDestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject _defaultObject;
    [SerializeField] private GameObject _physicalObject;

    public void PhysicalDestroy()
    {
        _defaultObject.SetActive(false);
        _physicalObject.SetActive(true);
    }
}
