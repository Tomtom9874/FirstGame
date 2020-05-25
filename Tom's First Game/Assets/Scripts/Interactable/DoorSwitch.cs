using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : Trigger
{
    public override void InteractedWith()
    {
        IsActive = true;
        ITriggerable objectAttachedTo = transform.parent.gameObject.GetComponent<ITriggerable>();
        objectAttachedTo.CheckTriggers();
    }
}
