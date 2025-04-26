using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RadioObject : MonoBehaviour
{
    [SerializeField] private RadioMusicSwitcher _radioMusicSwitcher;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnMouseOver()
    {
        _radioMusicSwitcher.Interact();
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}
