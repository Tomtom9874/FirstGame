using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractItemTrigger : DialogueTrigger
{
    [SerializeField] private string _item = "Null Item";
    [SerializeField] private int _itemAmount = 99999;

    public string Item{get{return _item;}}
    public int ItemAmount{get{return _itemAmount;}}

}
