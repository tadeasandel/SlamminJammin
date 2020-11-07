using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBase : MonoBehaviour
{
  public bool isObjectiveDone = false;

  public MainObjectiveBase mainObjectiveBase;

  public Action onObjectiveCompletedCallback;

  public IInteractableObject connectedInteraction;

  private void Awake()
  {
    connectedInteraction = GetComponent<IInteractableObject>();
    connectedInteraction.isReady = true;
  }

  public virtual void InitObjective(MainObjectiveBase mainObjectiveBase)
  {
    this.mainObjectiveBase = mainObjectiveBase;
  }

  public virtual void FinishObjective()
  {
    isObjectiveDone = true;
    mainObjectiveBase.CheckSubObjectives();
  }

  public virtual void Update()
  {
    if (!gameObject.activeSelf) { return; }
    if (isObjectiveDone) { return; }
  }
}
