using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Serialized
    [SerializeField] private Vector2 _lookDirection = new Vector2(0,-1);
    [SerializeField] private float _speed = .1f;

    // Private
    private bool _canMove;
    private bool _isMoving;
    private bool _hasAdjusted = false;
    private string _currentSceneName;
    private float _sprintFactor = 1.5f;
    private Vector2 _moveDirection;

    // Components
    Rigidbody2D _rigidbody2d;

    // Getters
    public Vector2 LookDirection {get{return _lookDirection;}}
    public bool IsMoving {get{return _isMoving;}}
    public bool CanMove{set{_canMove = value;}}
    public Vector2 MoveDirection{set{_moveDirection=value;}}

    private void Start()
    {
        _canMove = true;
        _moveDirection = new Vector2(0,0);
    }

    private void Awake()
    {
        // Get Components
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void FixedUpdate()
    {
        checkMoving();
        if (_canMove) MovePlayer();
        if (_isMoving) _lookDirection = _moveDirection;
        if (!_hasAdjusted) AdjustOnNewScene();
    } 

    private void checkMoving()
    {
        if (_canMove && ((_moveDirection.x != 0 || _moveDirection.y != 0))) _isMoving = true;
        else _isMoving = false;
    }

    private void MovePlayer()
    {
        if (_hasAdjusted)
        {
            Vector2 position = _rigidbody2d.position;
            position += _moveDirection * _speed;
            _rigidbody2d.MovePosition(position);
            GlobalPlayerController.SetPosition(_currentSceneName, _rigidbody2d.position);
        }
    }    

    private void AdjustOnNewScene()
    {
        if (GlobalPlayerController.CheckPositionsKey(_currentSceneName))
        {
            Vector2 previousPosition = GlobalPlayerController.GetPosition(_currentSceneName);
            _rigidbody2d.MovePosition(previousPosition + _lookDirection);
        }
        _hasAdjusted = true;
        GlobalPlayerController.SetPosition(_currentSceneName, _rigidbody2d.position);
    }

    // Public Methods
    public void ToggleSprintOn(){_speed *= _sprintFactor;}
    public void ToggleSprintOff(){_speed /= _sprintFactor;}
}
