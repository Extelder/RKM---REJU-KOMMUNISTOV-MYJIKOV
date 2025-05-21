using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDay : MonoBehaviour
{
    [SerializeField] private Day _day;

    public void Switch()
    {
        _day.End();
    }
}
