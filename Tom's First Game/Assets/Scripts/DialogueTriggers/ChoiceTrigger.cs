using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceTrigger : DialogueTrigger
{
    [SerializeField] private string _choiceText = "Null";

    public override void TriggerDialogue() 
    {
        IsActive = false;
        AdvanceNode();
        DialogueController.ChoiceText = _choiceText;
        DialogueController.ChoiceLoaded = true;
        DialogueController.StartDialogue(Dialogue);
    }
}

