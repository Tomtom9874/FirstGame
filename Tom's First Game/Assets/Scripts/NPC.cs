using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour,IInteractable
{
    private DialogueTrigger [] _dialoguetriggers;
    private int _currentDialogue = 0;

    private void Start()
    {
        _dialoguetriggers = GetComponents<DialogueTrigger>();
    }

    public void InteractedWith() 
    {
        for (int i = 0; i < _dialoguetriggers.Length; i++)
        {
            if (_dialoguetriggers[i].IsActive) _currentDialogue = i;
        }
        _dialoguetriggers[_currentDialogue].TriggerDialogue();   
    }
}
