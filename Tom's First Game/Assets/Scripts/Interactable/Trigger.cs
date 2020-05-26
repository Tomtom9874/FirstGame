using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite _activeSprite = null;
    [SerializeField] private Sprite _inactiveSprite = null;

    private bool _isActive = false;
    public bool IsActive {get {return _isActive;} set {_isActive = value;}}

    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (IsActive) _spriteRenderer.sprite = _activeSprite;
        else _spriteRenderer.sprite = _inactiveSprite;
    }

    public void InteractedWith()
    {
        IsActive = true;
        ITriggerable objectAttachedTo = transform.parent.gameObject.GetComponent<ITriggerable>();
        objectAttachedTo.CheckTriggers();
    }
}
