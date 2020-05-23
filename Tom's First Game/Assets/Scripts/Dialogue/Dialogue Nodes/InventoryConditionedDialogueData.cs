using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryConditionedDialogueData : AbstractDialogueData, IDialogueData
{
    [SerializeField] private DialogueNode _conditionalNode = null;
    public DialogueNode ConditionalNode{get{return _conditionalNode;}} 
    private ItemNode _itemNode;

    public override void Awake()
    {
        base.Awake();
        _itemNode = GetComponent<ItemNode>();
    }

    public DialogueNode GetNextNode()
    {
        if (ConditionMet()) 
        {
            return ConditionalNode;
        }
        else 
        {
            return Node.DefaultNode;
        }
    }

    private bool ConditionMet()
    {
        return GlobalInventoryController.ItemCount(_itemNode.Item.GetName()) >= _itemNode.ItemCount;
    }
}
