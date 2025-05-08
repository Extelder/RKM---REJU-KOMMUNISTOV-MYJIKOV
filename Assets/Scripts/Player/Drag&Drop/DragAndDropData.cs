using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropData : MonoBehaviour
{
    [field: SerializeField] public GameObject PassportMain;

    public static DragAndDropData Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more DragAndDropData&Drop");
        Debug.Break();
    }
}