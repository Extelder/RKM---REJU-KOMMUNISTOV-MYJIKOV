using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct CursorState
{
    public CursorLockMode CursorLockMode;
    public bool Visible;
}

public class GameCursor : MonoBehaviour
{
    [SerializeField] private Texture2D _cursor;

    public static GameCursor Instance { get; private set; }

    public CursorState PrevCursorState;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more GameCursor");
        Debug.Log(gameObject);
        Debug.Break();
    }

    private void Start()
    {
        Cursor.SetCursor(_cursor, new Vector2(0, 0), CursorMode.ForceSoftware);

        Hide();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Show();
        }
    }

    public void ToPrevState()
    {
        Cursor.visible = PrevCursorState.Visible;
        Cursor.lockState = PrevCursorState.CursorLockMode;
    }

    public void Show()
    {
        PrevCursorState.CursorLockMode = Cursor.lockState;
        PrevCursorState.Visible = Cursor.visible;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Hide()
    {
        PrevCursorState.CursorLockMode = Cursor.lockState;
        PrevCursorState.Visible = Cursor.visible;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}