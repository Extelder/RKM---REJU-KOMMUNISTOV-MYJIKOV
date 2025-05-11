using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Watch : MonoBehaviour
{
    [SerializeField] private ArasakaCutScene _arasakaCutScene;

    public void Yes()
    {
        PlayerPrefs.SetInt("GuideCompleate", 1);
        _arasakaCutScene.EndGuide();
    }

    public void No()
    {
        _arasakaCutScene.End();
    }
}