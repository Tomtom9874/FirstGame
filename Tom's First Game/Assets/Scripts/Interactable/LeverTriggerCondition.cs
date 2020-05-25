using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTriggerCondition : MonoBehaviour, ITriggerCondition
{
    [SerializeField] int _triggersNeeded = 0;
    Trigger [] _triggers;

    private void Awake()
    {
        _triggers = GetComponentsInChildren<Trigger>();
    }

    public bool CheckTriggers()
    {
        int count = 0;
        foreach (Trigger trigger in _triggers)
        {
            if (trigger.IsActive) count++;
        }
        return (count >= _triggersNeeded);
    }
}
