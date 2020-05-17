using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private string item = "NULL";
    [SerializeField]
    private string descriptionText = "NULL";
    private Image itemImage;
    private InventoryItemText descriptionTextBox;
    private InventoryItemText itemCountTextBox;

    private void Awake()
    {
        Component[] inventorytexts = GetComponentsInChildren<InventoryItemText>();
        foreach (InventoryItemText text in inventorytexts)
        {
            if (text.GetTextType() == "Item Description"){
                descriptionTextBox = text;
            }
            if (text.GetTextType() == "Item Count"){
                itemCountTextBox = text;
            }

        }
    }

    private void Update()
    {
        int itemCount = GlobalInventoryController.ItemCount(item);
        string itemCountString = itemCount.ToString();
        itemCountTextBox.SetText(itemCountString);
        descriptionTextBox.SetText(descriptionText);
    }
}
