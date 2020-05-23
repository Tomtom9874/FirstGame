using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : AbstractDialogueData, IDialogueData
{

    public DialogueNode GetNextNode()
    {
        return Node.DefaultNode;
    }
}

