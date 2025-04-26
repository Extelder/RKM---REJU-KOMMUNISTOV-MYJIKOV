using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDoor : MonoBehaviour
{
    [SerializeField] private int _id;

    public void Open()
    {
        PlayerPrefs.SetInt("CurrentScene", _id);
        SceneManager.LoadScene("Loading");
    }
}