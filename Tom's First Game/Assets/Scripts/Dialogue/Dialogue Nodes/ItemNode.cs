using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNode : MonoBehaviour
{
    [SerializeField] private bool _isItemCountChanger = false;
    [SerializeField] private Item _item = null;
    [SerializeField] private int _itemCount = 0;

    public Item Item{get{return _item;}}
    public int ItemCount{get{return _itemCount;}}

    public void ModifyItemCount() 
    {
        if (_isItemCountChanger) 
        {
            if (_itemCount > 0)
            {
                GlobalInventoryController.AddItem(Item.GetName(), ItemCount);
            }
            else 
            {
                GlobalInventoryController.RemoveItem(Item.GetName(), -ItemCount);
            }
            
        }
    }
}
