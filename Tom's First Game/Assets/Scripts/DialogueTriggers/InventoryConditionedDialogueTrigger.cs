using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryConditionedDialogueTrigger : DialogueTrigger
{
    [SerializeField] private bool _required = false;
    [SerializeField] private DialogueTrigger _conditionalNode = null;
    public DialogueTrigger ConditionalNode{get{return _conditionalNode;}} 
    
    private void Update()
    {
        if (IsActive && ConditionMet() && (!_required)) AdvanceNode();
    }

    public override void AdvanceNode()
    {
        IsActive = false;
        if (ItemCountChanger) ModifyItemCount();
        if (ConditionMet()) ConditionalNode.IsActive=true;
        else NextTrigger.IsActive = true;
    }

    private bool ConditionMet()
    {
        return GlobalPlayerController.ItemCount(Item) >= ItemCount;
    }
}
