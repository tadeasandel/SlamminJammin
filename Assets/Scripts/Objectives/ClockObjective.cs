using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockObjective : ObjectiveBase
{
    ClockInteraction clockInteraction;

    private void Start()
    {
        
    }

    public override void EnableObjective(Action onObjectiveCompletedCallback)
    {
        base.EnableObjective(onObjectiveCompletedCallback);
        clockInteraction = GetComponent<ClockInteraction>();

    }
    
}
