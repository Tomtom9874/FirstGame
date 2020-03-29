using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryConditionedDialogueTrigger : AbstractItemTrigger
{
    [SerializeField] private DialogueTrigger _conditionalNode = null;
    [SerializeField] private bool _required = false;
    
    private void Update()
    {
        if (IsActive && ConditionMet() && (!_required)) AdvanceNode();
    }

    public override void AdvanceNode()
    {
        IsActive = false;
        if (ConditionMet()) _conditionalNode.IsActive=true;
        else NextTrigger.IsActive = true;
    }

    private bool ConditionMet()
    {
        return GlobalPlayerController.ItemCount(Item) >= ItemAmount;
    }
}
