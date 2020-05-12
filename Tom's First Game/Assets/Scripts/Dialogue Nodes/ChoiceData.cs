using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceData : AbstractDialogueData, IDialogueData
{
    [SerializeField] private string _choiceText = "Null";

    public void TriggerDialogue() 
    {
        Node.IsActive = false;
        Controller.ChoiceText = _choiceText;
        Controller.ChoiceLoaded = true;
        Controller.StartDialogue(Node);
    }

    public void AdvanceNode()
    {
        Node.DefaultNode.IsActive = true;
        Node.DefaultNode.TriggerDialogue();
    }
}

