using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionConditionedDialogueTrigger : DialogueTrigger
{
    [SerializeField] private DialogueTrigger _yesNode = null;
    [SerializeField] private DialogueTrigger _noNode = null;
    [SerializeField] private string _decision = "null decision";
    
    public DialogueTrigger YesNode{get{return _yesNode;}} 
    public DialogueTrigger NoNode{get{return _noNode;}} 

    public override void AdvanceNode()
    {
        IsActive = false;
        int condition = GlobalPlayerController.CheckDecision(_decision);
        switch (condition)
        {
            case 0:
                NoNode.IsActive = true;
                break;
            case 1:
                YesNode.IsActive = true;
                break;
            default:
                NextTrigger.IsActive = true;
                break;
        }
    }
}
