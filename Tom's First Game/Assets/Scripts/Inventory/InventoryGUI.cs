using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGUI : MonoBehaviour
{
    [SerializeField]
    private InventoryItem slot;
    private Transform transform;
    private Vector3 offset;

    [SerializeField]
    private Item nextItem;

    private void Start()
    {
        transform = GetComponent<Transform>();
        offset = new Vector3(0, 5, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewSlot(nextItem);
        }
    }
    public void CreateNewSlot(Item i)
    {
        InventoryItem slotInstance;
        Debug.Log("SlotInstance");
        slotInstance = Instantiate(slot, transform.position + offset, Quaternion.identity, transform) as InventoryItem;
        offset += new Vector3(0, -1, 0);
        Item item = Instantiate(i) as Item;
        slotInstance.SetItem(item);
    }
}
