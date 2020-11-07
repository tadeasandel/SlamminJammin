using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObjectiveBase : MonoBehaviour
{
  public List<ObjectiveBase> subObjectives;

  public bool isMainObjectiveCompleted;

  private ObjectivesManager objectivesManager;

  public virtual void InitObjective(ObjectivesManager objectivesManager)
  {
    this.objectivesManager = objectivesManager;
    foreach (ObjectiveBase objective in subObjectives)
    {
      objective.InitObjective(this);
    }
  }

  public virtual void CheckSubObjectives()
  {
    foreach (ObjectiveBase objective in subObjectives)
    {
      if (!objective.isObjectiveDone)
      {
        return;
      }
    }
    FinishObjective();
  }

  public virtual void FinishObjective()
  {
    isMainObjectiveCompleted = true;
    objectivesManager.CheckObjectives();
  }
}