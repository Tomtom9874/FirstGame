using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private Item item;
    private string itemName = "NULL";
    private string itemDescription = "NULL";
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
        itemImage = GetComponentsInChildren<Image>()[1];
    }

    public void SetItem(Item i)
    {
        item = i;
        itemName = item.GetName();
        itemDescription = item.GetDescription();
        itemImage.sprite = item.GetSprite();
    }

    public string GetItemName()
    {
        return itemName;
    }

    private void Update()
    {
        int itemCount = GlobalInventoryController.ItemCount(itemName);
        string itemCountString = itemCount.ToString();
        itemCountTextBox.SetText(itemCountString);
        descriptionTextBox.SetText(itemDescription);
    }

    public void DeleteSlot()
    {
        Destroy(gameObject);
    }

}
