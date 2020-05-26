using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private PlayerController _movement;
    private Interactor _interactor;
    private InventoryGUI _inventoryGui;
    
    void Awake()
    {
        _movement = FindObjectOfType<PlayerController>();    
        _interactor = FindObjectOfType<Interactor>();
        _inventoryGui = FindObjectOfType<InventoryGUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            _interactor.Interact();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            _movement.ToggleSprint(); 
        }

        AxisInput();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GlobalPlayerController.PrintDecisions();
        }

        if (Input.GetKeyDown(KeyCode.I)) 
        {
            _inventoryGui.ToggleGui();
        }
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
