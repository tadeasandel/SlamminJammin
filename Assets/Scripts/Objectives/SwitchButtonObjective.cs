using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButtonObjective : ObjectiveBase
{
  SwitchButton switchButton;

  public override void EnableObjective(Action onObjectiveCompletedCallback)
  {
    base.EnableObjective(onObjectiveCompletedCallback);
    switchButton = GetComponent<SwitchButton>();
  }

  private void Update()
  {
    if (switchButton.isActive)
    {
      onObjectiveCompletedCallback();
    }
  }
}
