using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueNode  : MonoBehaviour
{
    [SerializeField] private string [] _dialogue = null;
    [SerializeField] private DialogueNode _defaultNode = null;

    public bool IsActive{get{return _isActive;} set{_isActive = value;}}
    public DialogueNode DefaultNode {get{return _defaultNode;}}
    public string [] Dialogue{get {return _dialogue;}}

    private bool _isActive = false;
    private IDialogueData _dialogueData;
    private ItemNode _itemNode;

    private void Awake()
    {
        _dialogueData = GetComponent<IDialogueData>();
        _itemNode = GetComponent<ItemNode>();
    }

    public void TriggerDialogue()
    {
        _dialogueData.TriggerDialogue();
    }

    public void AdvanceNode()
    {
        _dialogueData.AdvanceNode();
        if (_itemNode != null) 
        {
            _itemNode.ModifyItemCount();
        }
    }
}