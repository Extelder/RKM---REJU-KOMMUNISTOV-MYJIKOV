using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJudgeAnimator : MonoBehaviour
{
    public event Action Confirmed;

    public void OnConfirmed()
    {
        Confirmed.Invoke();
    }
}