using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
  public List<ObjectiveBase> objectivesInOrder;

  int currentObjetiveIndex = 0;

  public List<GameObject> objectsInState;

  Action onStateFinishedCallback;

  public virtual void StartState(Action onStateFinishedCallback)
  {
    this.onStateFinishedCallback = onStateFinishedCallback;
    foreach (GameObject objectToVisualize in objectsInState)
    {
      StartCoroutine(VisualizeObject(objectToVisualize));
    }
    objectivesInOrder[currentObjetiveIndex].EnableObjective(OnObjectiveCompleted);
  }

  public virtual void EndState(Action onStateEnded)
  {
    onStateFinishedCallback();
  }

  public virtual void OnObjectiveCompleted()
  {
    if (objectivesInOrder.Count <= currentObjetiveIndex + 1)
    {
      onStateFinishedCallback();
      return;
    }
    objectivesInOrder[++currentObjetiveIndex].EnableObjective(OnObjectiveCompleted);
  }

  private IEnumerator VisualizeObject(GameObject objectToVisualize)
  {
    MeshRenderer meshrenderer = objectToVisualize.GetComponent<MeshRenderer>();
    float alpha = 0;
    while (alpha <= 1)
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
