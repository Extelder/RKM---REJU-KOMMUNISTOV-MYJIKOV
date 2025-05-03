using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanConfirm : Confirmable
{
    [field: SerializeField] public override Transform JudgeTransform { get; protected set; }
    public override void Confirme()
    {
        
    }
}