using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGUI : MonoBehaviour
{
    [SerializeField] private InventoryItem _slot = null;
    [SerializeField] private List<Item> _allItems = new List<Item>();

    private Transform _GUITransform;
    private Vector3 _offset = new Vector3(0, 5, 0);
    private List<InventoryItem> _slots = new List<InventoryItem>();
    private int _finalSlotIndex = 0; 
    private bool _isActive = false;
    private PlayerController _playerScript;
    private List<Item> currentItems = new List<Item>();
    
    private void Start()
    {
        _GUITransform = GetComponent<Transform>();
        _playerScript = FindObjectOfType<PlayerController>();
    }

    public void AddSlot(Item addItem)
    {
        InventoryItem slotInstance;
        Debug.Log("SlotInstance");
        slotInstance = Instantiate(_slot, _GUITransform.position + SlotPosition(_finalSlotIndex), Quaternion.identity, _GUITransform) as InventoryItem;
        _finalSlotIndex++;
        slotInstance.SetItem(addItem);
        _slots.Add(slotInstance);
        currentItems.Add(addItem);
    }

    public void DeleteSlot(Item deleteItem)
    {
        Debug.Log("DeleteSlot");
        string itemName = deleteItem.GetName();
        for (int i = _slots.Count - 1; i >= 0; i--)
        {
            if (_slots[i].GetItemName() == itemName){
                InventoryItem slot = _slots[i];
                _slots.Remove(slot);
                slot.DeleteSlot();
                _finalSlotIndex--;
            }
        }
        currentItems.Remove(deleteItem);
    }

    private Vector3 SlotPosition(int index)
    {
        return _offset + new Vector3(0, -1, 0) * index;
    }

    public void ToggleGui()
    {
        _isActive = !_isActive;
        gameObject.SetActive(_isActive);
        if (_isActive)
        {
            updateSlots();
        }
        _playerScript.CanMove = !_isActive;
        Debug.Log(_isActive);
    }

    private void updateSlots()
    {
        Debug.Log("Update Slots");
        foreach (Item item in _allItems)
        {
            DeleteSlot(item);
        }
        foreach (Item item in _allItems)
        {
            if (GlobalInventoryController.ItemCount(item.GetName()) > 0)
            {
                AddSlot(item);
            }
        }
    }
}
