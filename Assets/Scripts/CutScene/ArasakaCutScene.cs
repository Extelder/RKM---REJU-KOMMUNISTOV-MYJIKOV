using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArasakaCutScene : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _cutScene;
    
    public void CutSceneEnd()
    {
          _player.SetActive(true);
          _cutScene.SetActive(false);
    }
}
