using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTree : MonoBehaviour
{
    private DialogueNode [] _dialogueNodes;
    private DialogueNode _currentNode;
    private DialogueController _controller;

    private void Start()
    {
        _dialogueNodes = GetComponentsInChildren<DialogueNode>();
        _currentNode = _dialogueNodes[0];
        _controller = FindObjectOfType<DialogueController>();
    }

    public void StartDialogue()
    {
        ChoiceData choiceData = _currentNode.GetComponent<ChoiceData>();
        if (choiceData != null)
        {
            string choiceText = choiceData.GetChoice();
            _controller.StartDialogueWithChoice(_currentNode, choiceText);
            return;
        }
        _controller.StartDialogue(_currentNode);
        _currentNode = _currentNode.GetNextNode();
    }   
 
}
