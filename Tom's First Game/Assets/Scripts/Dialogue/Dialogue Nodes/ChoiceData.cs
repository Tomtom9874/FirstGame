using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceData : AbstractDialogueData, IDialogueData
{
    [SerializeField] private Choice _choice = null;

    public DialogueNode GetNextNode()
    {
        return Node.DefaultNode;
    }

    public Choice GetChoice()
    {
        return _choice;
    }
}

