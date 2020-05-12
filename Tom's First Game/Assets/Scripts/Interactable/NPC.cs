using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : DialogueTree, IInteractable
{
    public void InteractedWith() 
    {
        for (int i = 0; i < DialogueNodes.Length; i++)
        {
            if (DialogueNodes[i].IsActive) CurrentNode = i;
        }
        DialogueNodes[CurrentNode].TriggerDialogue();   
    }
}
