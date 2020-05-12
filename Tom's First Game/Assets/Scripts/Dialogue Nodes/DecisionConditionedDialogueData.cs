using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionConditionedDialogueData: AbstractDialogueData, IDialogueData
{
    [SerializeField] private DialogueNode _yesNode = null;
    [SerializeField] private DialogueNode _noNode = null;
    [SerializeField] private string _decision = "null decision";
    
    public DialogueNode YesNode{get{return _yesNode;}} 
    public DialogueNode NoNode{get{return _noNode;}} 

    public void TriggerDialogue() 
    {
        Node.IsActive = false;
        AdvanceNode();
        Controller.ChoiceLoaded = false;
        Controller.StartDialogue(Node);
    }

    public void AdvanceNode()
    {
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
                Node.DefaultNode.IsActive = true;
                break;
        }
    }
}
