using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGUI : MonoBehaviour
{
    [SerializeField]
    private InventoryItem slot = null;
    private Transform GUITransform;
    private Vector3 offset;
    private List<InventoryItem> slots = new List<InventoryItem>();
    private int finalSlotIndex = 0; 

    [SerializeField]
    private Item nextItem = null;

    private void Start()
    {
        GUITransform = GetComponent<Transform>();
        offset = new Vector3(0, 5, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewSlot(nextItem);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DeleteSlot(nextItem);
        }
    }
    public void CreateNewSlot(Item i)
    {
        InventoryItem slotInstance;
        Debug.Log("SlotInstance");
        slotInstance = Instantiate(slot, GUITransform.position + SlotPosition(finalSlotIndex), Quaternion.identity, GUITransform) as InventoryItem;
        finalSlotIndex++;
        slotInstance.SetItem(i);
        slots.Add(slotInstance);
    }

    public void DeleteSlot(Item deleteItem)
    {
        Debug.Log("DeleteSlot");
        string itemName = deleteItem.GetName();
        for (int i = slots.Count - 1; i >= 0; i--)
        {
            if (slots[i].GetItemName() == itemName){
                slot = slots[i];
                slots.Remove(slot);
                slot.DeleteSlot();
                finalSlotIndex--;
            }
        }
    }

    private Vector3 SlotPosition(int index)
    {
        return offset + new Vector3(0, -1, 0) * index;
    }
}
