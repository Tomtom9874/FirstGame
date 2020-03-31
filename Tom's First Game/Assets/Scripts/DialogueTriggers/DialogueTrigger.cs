using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private string [] _dialogue = null;
    [SerializeField] private bool _isActive = false;
    [SerializeField] private DialogueTrigger _defaultNode = null;
    [SerializeField] private bool _itemCountChanger = false;
    [SerializeField] private string _item = "null";
    [SerializeField] private int _itemCount = 0;

    DialogueController _dialogueController;

    public string Item{get{return _item;}}
    public int ItemCount{get{return _itemCount;}}
    public bool ItemCountChanger{get{return _itemCountChanger;}set{_itemCountChanger=value;}}
    public bool IsActive{get{return _isActive;} set{_isActive = value;}}
    public DialogueTrigger NextTrigger {get{return _defaultNode;}}
    public string [] Dialogue{get {return _dialogue;}}
    public DialogueController DialogueController{get {return _dialogueController;}}
    

    private void Awake() {_dialogueController = FindObjectOfType<DialogueController>();}

    public virtual void TriggerDialogue() 
    {
        _isActive = false;
        if (ItemCountChanger) ModifyItemCount();
        AdvanceNode();
        _dialogueController.StartDialogue(_dialogue);
        _dialogueController.ChoiceLoaded = false;
    }

    public virtual void AdvanceNode()
    {
        _defaultNode.IsActive = true;
    }

    public void ModifyItemCount() {GlobalPlayerController.AddItem(Item, ItemCount);}
    
}