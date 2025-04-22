using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeChangeCursorMouseEnterExit : MonoBehaviour
{
    [SerializeField] private Texture2D _enterCursor;
    [SerializeField] private Texture2D _defaultCursor;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(_enterCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(_defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}