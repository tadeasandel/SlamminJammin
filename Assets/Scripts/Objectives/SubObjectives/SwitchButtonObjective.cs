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

  public override void Update()
  {
    base.Update();
    if (switchButton.isActive)
    {
      isObjectiveDone = true;
      onObjectiveCompletedCallback();
    }
  }
}
