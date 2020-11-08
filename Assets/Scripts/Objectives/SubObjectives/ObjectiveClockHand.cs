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
  }

  public void Update()
  {
    if (!gameObject.activeSelf) { return; }
    if (isObjectiveDone) { return; }
    if (interactionClockHand.isDone)
    {
      isObjectiveDone = true;
      FinishObjective();
    }
  }
}
