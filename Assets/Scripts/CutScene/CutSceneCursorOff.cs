using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCursorOff : MonoBehaviour
{
    public void StartCutScene()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndCutScene()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}