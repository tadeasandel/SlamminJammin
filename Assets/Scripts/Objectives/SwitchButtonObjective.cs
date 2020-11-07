using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwitchInteraction))]
public class SwitchButtonObjective : ObjectiveBase
{
  SwitchInteraction switchButton;

  public override void EnableObjective(Action onObjectiveCompletedCallback)
  {
    base.EnableObjective(onObjectiveCompletedCallback);
    switchButton = GetComponent<SwitchInteraction>();
  }

  private void Update()
  {
    if(!isObjectiveStarted) { return; }
    if (switchButton.isActive)
    {
      onObjectiveCompletedCallback();
    }
  }
}
