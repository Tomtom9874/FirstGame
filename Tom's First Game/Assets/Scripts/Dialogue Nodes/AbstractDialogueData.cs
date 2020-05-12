using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractDialogueData : MonoBehaviour
{
    private DialogueNode _node;
    DialogueController _dialogueController;

    public DialogueNode Node {get{return _node;}}
    public DialogueController Controller {get{return _dialogueController;}}

    public virtual void Awake()
    {
        _node = GetComponent<DialogueNode>();
        _dialogueController = FindObjectOfType<DialogueController>();
    }
}
