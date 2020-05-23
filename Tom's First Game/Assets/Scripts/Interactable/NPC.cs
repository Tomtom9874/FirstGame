using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : DialogueTree, IInteractable
{
    public void InteractedWith() 
    {
        StartDialogue();   
    }
}
