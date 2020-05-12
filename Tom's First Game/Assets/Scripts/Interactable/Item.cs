using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string _name = "null item";
    private Vector2 _position;
    private OnDestroy _destroyer;
    private DialogueData _dialogueData;

    private void Awake()
    {
        _position = GetComponent<Transform>().position;
        _destroyer = GetComponent<OnDestroy>();
        _dialogueData = GetComponentInChildren<DialogueData>();
    }

    public void InteractedWith() 
    {
        _dialogueData.TriggerDialogue();
        _destroyer.SelfDestruct();
        GlobalPlayerController.AddItem(_name, 1);
    }
}
