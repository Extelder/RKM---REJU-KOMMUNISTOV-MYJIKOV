using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPPCharacterGivePapers : KPPCharacterAnimatorState
{
    [SerializeField] private GameObject _paperInHand;
    [SerializeField] private GameObject _paperOnTable;

    private void Start()
    {
        _paperOnTable = DragAndDropData.Instance.PassportMain;
    }

    public override void Enter()
    {
        Animator.GivePapers();
        Animator.PaperGeted += GetPaper;
        Animator.PaperGived += GivePaper;
    }

    public override void Exit()
    {
        Animator.PaperGeted -= GetPaper;
        Animator.PaperGived -= GivePaper;
    }

    private void OnDisable()
    {
        Animator.PaperGeted -= GetPaper;
        Animator.PaperGived -= GivePaper;
    }

    public void GetPaper()
    {
        _paperInHand.SetActive(true);
    }

    public void GivePaper()
    {
        _paperInHand.SetActive(false);
        _paperOnTable.SetActive(true);
    }
}