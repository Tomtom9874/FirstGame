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
    BoxCollider2D [] _boxColliders;
    int _timeRemaining = -1;

    private void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining--;
        }
        if (_timeRemaining == 0)
        {
            OpenSecretDoor();
        }
    }

    private void Awake()
    {
        _openCondition = GetComponent<ITriggerCondition>();  
        _spriteRenderer = GetComponent<SpriteRenderer>();  
        _animator = GetComponent<MovableDoorAnimator>();
        _boxColliders = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D box in _boxColliders)
        {
            if (!box.isTrigger && !(box.size.x == 3))
            {
                box.enabled = false;
            }
        }
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
            _timeRemaining = 600;
        }
        else 
        {
            _spriteRenderer.sprite = _closedSprite;
        }
    }

    public void OpenSecretDoor()
    {
        foreach (BoxCollider2D box in _boxColliders)
        {
            if (!box.isTrigger)
            {
                box.enabled = !box.enabled;
                _timeRemaining = -1;
            }
        }
    }
}
