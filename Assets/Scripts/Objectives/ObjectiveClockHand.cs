﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionClockHand))]
public class ObjectiveClockHand : ObjectiveBase
{
  InteractionClockHand interactionClockHand;

  public override void EnableObjective(Action onObjectiveCompletedCallback)
  {
    base.EnableObjective(onObjectiveCompletedCallback);
    interactionClockHand = GetComponent<InteractionClockHand>();
  }
}