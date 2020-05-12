using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerable : DialogueTree, IInteractable
{
    [SerializeField] Sprite _closedSprite = null;
    [SerializeField] Sprite _openSprite = null;

    ITriggerCondition _openCondition;
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _openCondition = GetComponent<ITriggerCondition>();  
        _spriteRenderer = GetComponent<SpriteRenderer>();  
    }
    
    public void InteractedWith() 
    {
        for (int i = 0; i < DialogueNodes.Length; i++)
        {
            if (DialogueNodes[i].IsActive) CurrentNode = i;
        }
        DialogueNodes[CurrentNode].TriggerDialogue();   
    }

    private void Update()
    {
        if (_openCondition.CheckTriggers()) _spriteRenderer.sprite = _openSprite;
        else _spriteRenderer.sprite = _closedSprite;
    }
}
