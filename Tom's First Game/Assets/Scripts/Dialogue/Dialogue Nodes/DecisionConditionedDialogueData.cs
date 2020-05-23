using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionConditionedDialogueData: AbstractDialogueData, IDialogueData
{
    [SerializeField] private DialogueNode _yesNode = null;
    [SerializeField] private DialogueNode _noNode = null;
    [SerializeField] private string _decision = "null decision";

    public DialogueNode GetNextNode()
    {
        int condition = GlobalPlayerController.CheckDecision(_decision);
        switch (condition)
        {
            case 0:
                return _noNode;
            case 1:
                return _yesNode;
            default:
                return Node.DefaultNode;
        }
    }
}
