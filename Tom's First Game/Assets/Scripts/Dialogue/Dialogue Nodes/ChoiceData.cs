using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceData : AbstractDialogueData, IDialogueData
{
    [SerializeField] private Choice _choice = null;

    public override void Awake()
    {
        base.Awake();
        _choice = GetComponentsInChildren<Choice>()[0];
        Debug.Log(Node.DefaultNode);
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

