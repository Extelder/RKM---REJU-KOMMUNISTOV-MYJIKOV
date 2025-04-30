using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBreak : MonoBehaviour, IConfirmable
{
    [field: SerializeField] public Collider Collider { get; set; }
}