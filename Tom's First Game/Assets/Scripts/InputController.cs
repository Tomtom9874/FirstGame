using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private PlayerController _movement;
    private Interactor _interactor;
    
    void Awake()
    {
        _movement = FindObjectOfType<PlayerController>();    
        _interactor = FindObjectOfType<Interactor>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) _interactor.Interact();

        if (Input.GetKeyDown(KeyCode.LeftShift)) _movement.ToggleSprintOn(); 
        if (Input.GetKeyUp(KeyCode.LeftShift)) _movement.ToggleSprintOff();
        AxisInput();
        if (Input.GetKeyDown(KeyCode.Space)) GlobalPlayerController.PrintDecisions();
        if (Input.GetKeyDown(KeyCode.I)) GlobalPlayerController.PrintInventory();
        
    }

    private void AxisInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        direction.Normalize();
        _movement.MoveDirection = direction;
    }
   
}
