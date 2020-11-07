﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClockInteraction))]
public class ClockObjective : ObjectiveBase
{
  ClockInteraction clockInteraction;

  public HourTime correctClockTime;

  public override void EnableObjective(Action onObjectiveCompletedCallback)
  {
    base.EnableObjective(onObjectiveCompletedCallback);
    clockInteraction = GetComponent<ClockInteraction>();
  }
}

[System.Serializable]
public struct HourTime
{
  public float firstDigit;
  public float secondDigit;
  public float thirdDigit;
  public float fourthDigit;

  public HourTime(float firstDigit, float secondDigit, float thirdDigit, float fourthDigit)
  {
    this.firstDigit = firstDigit;
    this.secondDigit = secondDigit;
    this.thirdDigit = thirdDigit;
    this.fourthDigit = fourthDigit;
  }
}