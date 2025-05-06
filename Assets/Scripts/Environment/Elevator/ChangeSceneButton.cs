using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour, Iinteractable
{
    [SerializeField] private int _sceneIndex;
    [SerializeField] private AudioSource _dindinSound;

    public void Interact()
    {
        _dindinSound.Play();
        PlayerPrefs.SetInt("CurrentScene", _sceneIndex);
        SceneManager.LoadScene("Loading");
    }
}