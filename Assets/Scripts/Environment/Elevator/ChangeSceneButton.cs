using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour, Iinteractable
{
    [SerializeField] private int _sceneIndex;

    public void Interact()
    {
        PlayerPrefs.SetInt("CurrentScene", _sceneIndex);
        SceneManager.LoadScene("Loading");
    }
}