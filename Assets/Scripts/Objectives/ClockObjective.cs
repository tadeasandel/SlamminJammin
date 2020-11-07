using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClockInteraction))]
public class ClockObjective : ObjectiveBase
{
    ClockInteraction clockInteraction;

    public override void EnableObjective(Action onObjectiveCompletedCallback)
    {
        base.EnableObjective(onObjectiveCompletedCallback);
        clockInteraction = GetComponent<ClockInteraction>();
    }    
}
