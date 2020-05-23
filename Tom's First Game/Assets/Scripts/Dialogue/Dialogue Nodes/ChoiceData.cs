using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceData : AbstractDialogueData, IDialogueData
{
    [SerializeField] private string _choiceText = "Null";

    public DialogueNode GetNextNode()
    {
        return Node.DefaultNode;
    }

    public string GetChoice()
    {
        return _choiceText;
    }
}

