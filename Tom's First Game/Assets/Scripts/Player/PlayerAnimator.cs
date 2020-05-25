using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerController _playerMovement;
    Vector2 _lookDirection;
    Animator _animator;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }
    private void Update() 
    {
        SetAnimatorValues();
    }
    
    public void SetAnimatorValues()
    {
        _lookDirection = _playerMovement.LookDirection;
        _animator.SetFloat("LookX", _lookDirection.x);
        _animator.SetFloat("LookY", _lookDirection.y);
        _animator.SetBool("isMoving", _playerMovement.IsMoving);
    }    
}
