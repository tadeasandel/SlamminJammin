using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionClockHand))]
public class ObjectiveClockHand : ObjectiveBase
{
  InteractionClockHand interactionClockHand;

  public override void InitObjective(MainObjectiveBase mainObjectiveBase)
  {
    base.InitObjective(mainObjectiveBase);
    interactionClockHand = GetComponent<InteractionClockHand>();
       /// onObjectiveCompletedCallback();
  }
   private void Update()
    {
        
        if (interactionClockHand.isDone)
        {
            isObjectiveDone = true;
            onObjectiveCompletedCallback();
        }
    }

}
