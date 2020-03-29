using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private string [] _dialogue = null;
    DialogueController _dialogueController;
    [SerializeField] private bool _isActive = false;
    [SerializeField] private DialogueTrigger _nextTrigger = null;

    public bool IsActive{get{return _isActive;} set{_isActive = value;}}
    public DialogueTrigger NextTrigger {get{return _nextTrigger;}}
    public string [] Dialogue{get {return _dialogue;}}
    public DialogueController DialogueController{get {return _dialogueController;}}
    

    private void Awake()
    {
        _dialogueController = FindObjectOfType<DialogueController>();
    }

    public virtual void TriggerDialogue() 
    {
        _isActive = false;
        AdvanceNode();
        _dialogueController.StartDialogue(_dialogue);
        _dialogueController.ChoiceLoaded = false;
    }

    public virtual void AdvanceNode()
    {
        _nextTrigger.IsActive = true;
    }
}