using UnityEngine;

public class PassConfirm : Confirmable
{
    [field: SerializeField] public override Transform JudgeTransform { get; protected set; }

    public override void Confirme()
    {
        
    }
}