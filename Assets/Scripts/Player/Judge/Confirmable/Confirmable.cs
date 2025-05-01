using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Confirmable : MonoBehaviour
{
    [field:SerializeField] abstract public Transform JudgeTransform { get; protected set; }
}