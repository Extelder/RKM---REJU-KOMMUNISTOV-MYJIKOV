using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickAndDropItem : MonoBehaviour
{
    [SerializeField] private DragAndDropObject _dragAndDropObject;
    [SerializeField] private AudioSource _pickSound;
    [SerializeField] private AudioSource _dropSound;
    private void OnEnable()
    {
        _dragAndDropObject.PickedUp += OnItemPickedUp;
        _dragAndDropObject.DropedDown += OnItemDropedDown;
    }

    private void OnItemPickedUp()
    {
        _pickSound.Play();
    }

    private void OnItemDropedDown()
    {
        _dropSound.Play();
    }

    private void OnDisable()
    {
        _dragAndDropObject.PickedUp -= OnItemPickedUp;
        _dragAndDropObject.DropedDown -= OnItemDropedDown;
    }
}
