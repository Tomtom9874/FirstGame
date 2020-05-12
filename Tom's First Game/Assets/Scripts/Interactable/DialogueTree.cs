using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTree : MonoBehaviour
{
    private DialogueNode [] _dialogueNodes;
    private int _currentNode = 0;

    public DialogueNode [] DialogueNodes { get {return _dialogueNodes;} set {_dialogueNodes = value;} }
    public int CurrentNode { get {return _currentNode;} set {_currentNode = value;} }

    private void Start()
    {
        DialogueNodes = GetComponentsInChildren<DialogueNode>();
        DialogueNodes[0].IsActive = true;
    }   
}
