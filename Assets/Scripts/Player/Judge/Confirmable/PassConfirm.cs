using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassConfirm : Confirmable
{
    [field: SerializeField] public override Transform JudgeTransform { get; protected set; }
}