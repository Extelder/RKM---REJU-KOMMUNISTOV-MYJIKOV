using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Watch : MonoBehaviour
{
    [SerializeField] private int _guideLevelIndex = 4;
    [SerializeField] private ArasakaCutScene _arasakaCutScene;

    public void Yes()
    {
        SceneManager.LoadScene(_guideLevelIndex);
    }

    public void No()
    {
        _arasakaCutScene.EndGuide();
    }
}