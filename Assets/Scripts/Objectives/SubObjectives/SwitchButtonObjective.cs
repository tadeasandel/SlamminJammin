using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwitchInteraction))]
public class SwitchButtonObjective : ObjectiveBase
{
  SwitchInteraction switchButton;

  public override void InitObjective(MainObjectiveBase mainObjectiveBase)
  {
    base.InitObjective(mainObjectiveBase);
    switchButton = GetComponent<SwitchInteraction>();
  }

  public void Update()
  {
    if (!gameObject.activeSelf) { return; }
    if (isObjectiveDone) { return; }
    if (switchButton.isActive)
    {
      isObjectiveDone = true;
      FinishObjective();
    }
  }
}
