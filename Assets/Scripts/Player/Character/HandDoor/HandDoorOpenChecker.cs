using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HandDoorOpenChecker : MonoBehaviour
{
    [SerializeField] private TwoBoneIKConstraint _ik;
    [SerializeField] private float _weightChangeSpeed;
    [SerializeField] private AudioSource _doorSound;

    private float _tagetWeight;

    private void Update()
    {
        _ik.weight = Mathf.Lerp(_ik.weight, _tagetWeight, _weightChangeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<InteractDoor>(out InteractDoor door))
        {
            door.Opening();
            _tagetWeight = 1;
            _doorSound.Play();
        }

        if (other.TryGetComponent<ChangeSceneDoor>(out ChangeSceneDoor changeSceneDoor))
        {
            changeSceneDoor.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<InteractDoor>(out InteractDoor door))
        {
            door.StopOpening();
            _tagetWeight = 0;
        }
    }
}