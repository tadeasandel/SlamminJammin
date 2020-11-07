using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBase : MonoBehaviour
{
  public bool isObjectiveStarted = false;
  public bool isObjectiveDone = false;

  public Action onObjectiveCompletedCallback;

  public IInteractableObject connectedInteraction;

  private void Awake()
  {
    connectedInteraction = GetComponent<IInteractableObject>();
    connectedInteraction.isReady = false;
  }

  public virtual void EnableObjective(Action onObjectiveCompletedCallback)
  {
    isObjectiveStarted = true;
    connectedInteraction.isReady = true;
    this.onObjectiveCompletedCallback = onObjectiveCompletedCallback;
  }
}
