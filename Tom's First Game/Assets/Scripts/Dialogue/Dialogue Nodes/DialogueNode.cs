using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueNode  : MonoBehaviour
{
    [SerializeField] private string [] _dialogue = null;
    [SerializeField] private DialogueNode _defaultNode = null;

    public DialogueNode DefaultNode {get{return _defaultNode;}}
    public string [] Dialogue{get {return _dialogue;}}

    private IDialogueData _dialogueData;
    private ItemNode _itemNode;

    private void Awake()
    {
        _dialogueData = GetComponent<IDialogueData>();
        _itemNode = GetComponent<ItemNode>();
    }

    public DialogueNode GetNextNode()
    {
        DialogueNode nextNode = _dialogueData.GetNextNode();
        if (_itemNode != null) 
        {
            _itemNode.ModifyItemCount();
        }
        return nextNode;
    }
}