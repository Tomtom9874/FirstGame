using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceData : AbstractDialogueData, IDialogueData
{
    [SerializeField] private Choice _choice = null;

    private void Awake()
    {
        _choice = GetComponentsInChildren<Choice>()[0];
    }
    public DialogueNode GetNextNode()
    {
        return Node.DefaultNode;
    }

    public Choice GetChoice()
    {
        return _choice;
    }
}

