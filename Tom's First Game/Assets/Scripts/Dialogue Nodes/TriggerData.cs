using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerData : DialogueData
{
    [SerializeField] private int _requiredTriggers = 9999;
    [SerializeField] private DialogueNode _conditionalNode = null;
    public DialogueNode ConditionalNode{get{return _conditionalNode;}} 
    private Trigger [] _triggers;

    public override void Awake()
    {
        base.Awake();
        _triggers = GetComponentsInChildren<Trigger>();
    }

    private bool ConditionMet()
    {
        int activeTriggers = 0;
        foreach (Trigger trigger in _triggers)
        {
            if (trigger.IsActive) activeTriggers++;
        }
        return (activeTriggers >= _requiredTriggers);
    }
}
