using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNode : MonoBehaviour
{
    [SerializeField] private bool _isItemCountChanger = false;
    [SerializeField] private string _item = "null";
    [SerializeField] private int _itemCount = 0;

    public string Item{get{return _item;}}
    public int ItemCount{get{return _itemCount;}}

    public void ModifyItemCount() 
    {
        if (_isItemCountChanger) GlobalPlayerController.AddItem(Item, ItemCount);
    }
}
