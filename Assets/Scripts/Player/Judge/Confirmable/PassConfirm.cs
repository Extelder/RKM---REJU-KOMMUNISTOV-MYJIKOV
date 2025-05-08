using UnityEngine;

public class PassConfirm : Confirmable
{
    [SerializeField] private PlayerDragAndDrop _dragAndDrop;
    [field: SerializeField] public override Transform JudgeTransform { get; protected set; }

    public override void Confirme()
    {
        _dragAndDrop.Character.OnPass();
    }
}