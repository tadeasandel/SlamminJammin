using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
  public List<ObjectiveBase> objectivesInOrder;
  public List<ObjectiveBase> objectivesWithoutOrder;

  public int currentObjetiveIndex = 0;

  public List<GameObject> objectsInState;

  public Action onStateFinishedCallback;

  public bool orderedObjectivesDone;
  public bool unorderedObjectivesDone;

  public virtual void StartState(Action onStateFinishedCallback)
  {
    this.onStateFinishedCallback = onStateFinishedCallback;
    foreach (GameObject objectToVisualize in objectsInState)
    {
      StartCoroutine(VisualizeObject(objectToVisualize));
    }
    foreach (ObjectiveBase objective in objectivesWithoutOrder)
    {
      objective.EnableObjective(() => { });
    }
    objectivesInOrder[currentObjetiveIndex].EnableObjective(OnObjectiveCompleted);
  }

  public virtual void RefreshUnorderedObjectives()
  {
    foreach (ObjectiveBase objective in objectivesWithoutOrder)
    {
      if (!objective.isObjectiveDone)
      {
        return;
      }
    }
    unorderedObjectivesDone = true;
  }

  public virtual void CheckStateCondition()
  {
    if (unorderedObjectivesDone && orderedObjectivesDone)
    {
      onStateFinishedCallback();
    }
  }

  public virtual void EndState(Action onStateEnded)
  {
    onStateEnded();
  }

  public virtual void OnObjectiveCompleted()
  {
    if (objectivesInOrder.Count <= currentObjetiveIndex + 1)
    {
      onStateFinishedCallback();
      return;
    }
    currentObjetiveIndex++;
    objectivesInOrder[currentObjetiveIndex].EnableObjective(OnObjectiveCompleted);
  }

  private IEnumerator VisualizeObject(GameObject objectToVisualize)
  {
    MeshRenderer meshrenderer = objectToVisualize.GetComponent<MeshRenderer>();
    float alpha = 0;
    while (alpha >= 1)
    {
      alpha += Time.deltaTime;
      meshrenderer.material.color = new Color(meshrenderer.material.color.r, meshrenderer.material.color.g, meshrenderer.material.color.b, alpha);
      yield return null;
    }
  }

  public virtual void UpdateObjectiveState()
  {

  }
}