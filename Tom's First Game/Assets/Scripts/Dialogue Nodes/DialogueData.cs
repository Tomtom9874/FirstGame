using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : AbstractDialogueData, IDialogueData
{

    public void TriggerDialogue()
    {
        Node.IsActive = false;
        Controller.StartDialogue(Node);
        Controller.ChoiceLoaded = false;
    }

    public void AdvanceNode()
    {
        Node.DefaultNode.IsActive = true;
    }
}

