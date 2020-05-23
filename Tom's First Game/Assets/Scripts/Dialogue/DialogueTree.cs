﻿using System.Collections;
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

    public void StartTreeDialogue()
    {
        if (_currentNode.GetDialogue().Length > 0) Debug.Log(_currentNode.GetDialogue()[0]);
        else Debug.Log("Empty Dialogue");

        if (_currentNode.GetIsAutoAdvancer())
        {
            Interactor interactor = FindObjectOfType<Interactor>();
            interactor.MustInteract();
        }
        string [] lines = _currentNode.GetDialogue();
        _currentNode = _currentNode.GetNextNode();
        ChoiceData choiceData = _currentNode.GetComponent<ChoiceData>();
        if (choiceData != null)
        {
            string choiceText = choiceData.GetChoice();
            _controller.StartDialogueWithChoice(lines, choiceText);
        }
        else
        {
            _controller.StartDialogue(lines);
        }
    }   
}
