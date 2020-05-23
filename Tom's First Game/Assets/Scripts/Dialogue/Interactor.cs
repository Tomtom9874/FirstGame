using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Serialized
    [SerializeField]
    private int _talkDelay = 5;
    [SerializeField]
    private float _talkDistance = 1f;
    
    // Private
    private PlayerController _player;
    private Rigidbody2D _rigidbody;
    private bool _canTalk = true; 
    private int _currentTalkDelay;
    private bool _autoInteract = false;

    // Setter
    public void StartConversation()
    {
        _canTalk = false;
        _player.Pause();
    }

    public void EndConversation()
    {
        _canTalk = true;
        if (_autoInteract)
        {
            _currentTalkDelay = 0;
            _player.Pause();
        }
        else
        {
            _currentTalkDelay = _talkDelay;
            _player.Unpause();
        }
    }

    public void MustInteract()
    {
        _autoInteract = true;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();  
        _player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        _currentTalkDelay--;
        if (_autoInteract)
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (_currentTalkDelay < 0 && _canTalk)
        {
            RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position + Vector2.up * 0.2f, _player.LookDirection, _talkDistance, (1 << LayerMask.NameToLayer("NPC") | (1 << LayerMask.NameToLayer("Items"))));
            if (hit.collider != null)
            {
                IInteractable character = hit.collider.GetComponent<IInteractable>();
                _autoInteract = false;
                character.InteractedWith();
            }
        }
    }
}
