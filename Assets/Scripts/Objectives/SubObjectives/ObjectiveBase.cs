using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBase : MonoBehaviour
{
  public bool isObjectiveDone = false;

  public MainObjectiveBase mainObjectiveBase;

  public virtual void InitObjective(MainObjectiveBase mainObjectiveBase)
  {
    this.mainObjectiveBase = mainObjectiveBase;
  }

  public virtual void FinishObjective()
  {
    isObjectiveDone = true;
    mainObjectiveBase.CheckSubObjectives();
  }
}
