using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanConfirm : Confirmable
{
    [SerializeField] private PlayerDragAndDrop _dragAndDrop;
    [field: SerializeField] public override Transform JudgeTransform { get; protected set; }

    public override void Confirme()
    {
        _dragAndDrop.Character.OnBan();
    }
}