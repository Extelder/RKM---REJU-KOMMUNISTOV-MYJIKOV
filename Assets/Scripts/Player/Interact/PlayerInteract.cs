using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : RaycastBehaviour
{
    [SerializeField] private float _checkRate;
    [SerializeField] private GameObject _interactButton;

    private Iinteractable _interactable;

    private void OnEnable()
    {
        StartCoroutine(CheckingInteractable());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    public void TryInteract()
    {
        if (_interactable != null)
        {
            _interactable.Interact();
            _interactButton.SetActive(false);
        }
    }

    private IEnumerator CheckingInteractable()
    {
        while (true)
        {
            if (GetHitCollider(out Collider collider))
            {
                if (collider.TryGetComponent<Iinteractable>(out Iinteractable interactable))
                {
                    _interactable = interactable;
                    _interactButton.SetActive(true);
                }
                else
                {
                    _interactable = null;
                    _interactButton.SetActive(false);
                }
            }
            else
            {
                _interactable = null;
                _interactButton.SetActive(false);
            }

            yield return new WaitForSeconds(_checkRate);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(Camera.position, Camera.forward * Range, Color.green);
    }
}