using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueNode  : MonoBehaviour
{
    [SerializeField] private string [] _dialogue = null;
    [SerializeField] private DialogueNode _defaultNode = null;
    [SerializeField] private bool _isAutoAdvancer = false;

    public DialogueNode DefaultNode {get{return _defaultNode;}}
    

    private IDialogueData _dialogueData;
    private ItemNode _itemNode;
    
    public string [] GetDialogue()
    {
        return _dialogue;
    }

    private void Awake()
    {
        _dialogueData = GetComponent<IDialogueData>();
        _itemNode = GetComponent<ItemNode>();
    }

    public bool GetIsAutoAdvancer()
    {
        return _isAutoAdvancer;
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