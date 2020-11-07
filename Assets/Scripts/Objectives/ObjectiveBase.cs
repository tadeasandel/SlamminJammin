using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBase : MonoBehaviour
{
  public bool isObjectiveStarted = false;
  public bool isObjectiveDone = false;

  public Action onObjectiveCompletedCallback;

  public virtual void EnableObjective(Action onObjectiveCompletedCallback)
  {
    isObjectiveStarted = true;
    this.onObjectiveCompletedCallback = onObjectiveCompletedCallback;
  }
}
