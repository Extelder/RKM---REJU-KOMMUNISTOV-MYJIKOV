using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioStopMusicObject : MonoBehaviour
{
    [SerializeField] private AudioSource _radioAudio;
    [SerializeField] private GameObject _redSphere;
    [SerializeField] private GameObject _greenSphere;

    private void OnMouseDown()
    {
        _radioAudio.Stop();
        _redSphere.SetActive(true);
        _greenSphere.SetActive(false);
    }
}
