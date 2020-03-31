using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string _name = "null item";
    private Vector2 _position;
    private OnDestroy _destroyer;
    private DialogueTrigger _dialogueTrigger;

    private void Awake()
    {
        _position = GetComponent<Transform>().position;
        _destroyer = GetComponent<OnDestroy>();
        _dialogueTrigger = GetComponentInChildren<DialogueTrigger>();
    }

    public void InteractedWith() 
    {
        _dialogueTrigger.TriggerDialogue();
        _destroyer.SelfDestruct();
        GlobalPlayerController.AddItem(_name, 1);
    }
}
