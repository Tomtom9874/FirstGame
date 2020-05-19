using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGUI : MonoBehaviour
{
    [SerializeField]
    private InventoryItem _slot = null;
    private Transform _GUITransform;
    private Vector3 _offset;
    private List<InventoryItem> _slots = new List<InventoryItem>();
    private int _finalSlotIndex = 0; 

    [SerializeField]
    private List<Item> _allItems = new List<Item>();

    private void Start()
    {
        _GUITransform = GetComponent<Transform>();
        _offset = new Vector3(0, 5, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewSlot(_allItems[0]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DeleteSlot(_allItems[0]);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(_allItems);
        }
    }
    public void CreateNewSlot(Item i)
    {
        InventoryItem slotInstance;
        Debug.Log("SlotInstance");
        slotInstance = Instantiate(_slot, _GUITransform.position + SlotPosition(_finalSlotIndex), Quaternion.identity, _GUITransform) as InventoryItem;
        _finalSlotIndex++;
        slotInstance.SetItem(i);
        _slots.Add(slotInstance);
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
    }

    private Vector3 SlotPosition(int index)
    {
        return _offset + new Vector3(0, -1, 0) * index;
    }
}
