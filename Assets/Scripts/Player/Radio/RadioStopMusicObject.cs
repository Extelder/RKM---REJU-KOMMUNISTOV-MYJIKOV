using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RadioStopMusicObject : MonoBehaviour
{
    [SerializeField] private AudioSource _radioAudio;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private RadioMusicSwitcher _radioMusicSwitcher;
    [SerializeField] private GameObject _redSphere;
    [SerializeField] private GameObject _greenSphere;

    private void OnMouseDown()
    {
        _radioAudio.Stop();
        _text.gameObject.SetActive(false);
        _radioMusicSwitcher.Index--;
        _redSphere.SetActive(true);
        _greenSphere.SetActive(false);
    }
}
