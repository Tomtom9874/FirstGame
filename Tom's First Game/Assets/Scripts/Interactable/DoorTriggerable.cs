using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerable : DialogueTree, IInteractable, ITriggerable
{
    [SerializeField] Sprite _closedSprite = null;
    [SerializeField] Sprite _openSprite = null;

    ITriggerCondition _openCondition;
    SpriteRenderer _spriteRenderer;
    private MovableDoorAnimator _animator;

    private void Awake()
    {
        _openCondition = GetComponent<ITriggerCondition>();  
        _spriteRenderer = GetComponent<SpriteRenderer>();  
        _animator = GetComponent<MovableDoorAnimator>();
    }
    
    public void InteractedWith() 
    {
        StartTreeDialogue();   
    }

    public void CheckTriggers()
    {
        if (_openCondition.CheckTriggers()) 
        {
            _spriteRenderer.sprite = _openSprite;
            if (_animator != null)
            {
                _animator.PlayOpenAnimation();
            }
            
        }
        else 
        {
            _spriteRenderer.sprite = _closedSprite;
        }
    }
}
