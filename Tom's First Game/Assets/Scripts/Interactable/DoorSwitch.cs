using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : Trigger
{
    public override void InteractedWith()
    {
        Debug.Log("Switched");
        IsActive = true;
    }
}
