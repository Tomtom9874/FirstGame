using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInputController : MonoBehaviour
{
    DialogueController _dialogueController;

    private void Start()
    {
        _dialogueController = GetComponent<DialogueController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            _dialogueController.ChangeSelection();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _dialogueController.ReceiveSelection();
        }
    }
}
