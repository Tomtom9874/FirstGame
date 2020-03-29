using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemDialogueTrigger : AbstractItemTrigger
{
    public override void AdvanceNode()
    {
        GlobalPlayerController.AddItem(Item, -ItemAmount);
        IsActive = false;
        NextTrigger.IsActive = true;
    }
}
