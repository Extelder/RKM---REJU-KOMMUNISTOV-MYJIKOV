using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class Prank : MonoBehaviour
{
    [SerializeField] private GameObject _prankCamera;
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private Transform _targetPoint;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController PlayerController))
        {
            _collider.enabled = false;
            _prankCamera.SetActive(true);
            _mainCamera.SetActive(false);
            _targetPoint.parent = null;
            _targetPoint.position = _prankCamera.transform.position;

            StartCoroutine(Pranking());
        }
    }

    private IEnumerator Pranking()
    {
        yield return new WaitForSeconds(5);

        _mainCamera.SetActive(true);
        _prankCamera.SetActive(false);
        _targetPoint.parent = _mainCamera.transform;
        _targetPoint.position = _mainCamera.transform.position;
    }
}