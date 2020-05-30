using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionConditionedDialogueData: AbstractDialogueData, IDialogueData
{
    [SerializeField] private DialogueNode [] _decisionNodes = null;
    [SerializeField] private Choice _decision = null;
    
    private void Start()
    {
        if (_decision.GetAllChoices().Length != _decisionNodes.Length)
        {
            Debug.Log(_decision.GetAllChoices().Length);
            Debug.Log(_decisionNodes.Length);
            Debug.LogError("No node selcted for some choice.");
        }
    }

    public DialogueNode GetNextNode()
    {
        int condition = _decision.GetCurrentChoiceIndex();
        // Change this from a switch to a list that returns the index given.
            if (condition == -1) 
            {
                return Node.DefaultNode;
            }
            else 
            {
                return _decisionNodes[condition];
            }
    }
}
