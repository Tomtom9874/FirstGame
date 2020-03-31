using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IConditional
{
    DialogueTrigger ConditionalNode{get;} 
    bool ConditionMet();
}

