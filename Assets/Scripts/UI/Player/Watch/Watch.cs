using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Watch : MonoBehaviour
{
    [SerializeField] private GameObject _timeCanvas;
    [SerializeField] private GameObject _yesNoCanvas;
    [SerializeField] private GameObject _guideCanvas;

    [SerializeField] private ArasakaCutScene _arasakaCutScene;

    public void Yes()
    {
        _timeCanvas.SetActive(true);
        _guideCanvas.SetActive(true);
        _yesNoCanvas.SetActive(false);
        PlayerPrefs.SetInt("GuideCompleate", 1);
        _arasakaCutScene.EndGuide();
    }

    public void No()
    {
        _arasakaCutScene.EndGuide();
    }
}