using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RadioMusicSwitcherObject : MonoBehaviour
{
    [SerializeField] private RadioMusicSwitcher _radioMusicSwitcher;

    private void OnMouseDown()
    {
        _radioMusicSwitcher.Interact();
    }
}
