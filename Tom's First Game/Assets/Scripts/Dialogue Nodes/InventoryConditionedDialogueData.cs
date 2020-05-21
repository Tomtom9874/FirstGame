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

    private void Update()
    {
        if (Node.IsActive && ConditionMet()) AdvanceNode();
    }

    public void TriggerDialogue() 
    {
        Debug.Log("ICDD Trigger Dialogue");
        _itemNode.ModifyItemCount();
        Node.IsActive = false;
        Controller.StartDialogue(Node);
        Controller.ChoiceLoaded = false;
    }

    public void AdvanceNode()
    {
        if (ConditionMet()) ConditionalNode.IsActive=true;
        else Node.DefaultNode.IsActive = true;
    }

    private bool ConditionMet()
    {
        return GlobalInventoryController.ItemCount(_itemNode.Item.GetName()) >= _itemNode.ItemCount;
    }
}
