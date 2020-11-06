using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBase : MonoBehaviour
{
  public bool isObjectiveDone = false;

  public Action onObjectiveCompletedCallback;

  public virtual void EnableObjective(Action onObjectiveCompletedCallback)
  {
    this.onObjectiveCompletedCallback = onObjectiveCompletedCallback;
  }
}
