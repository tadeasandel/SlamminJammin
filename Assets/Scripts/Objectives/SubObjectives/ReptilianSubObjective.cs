using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptilianSubObjective : ObjectiveBase
{
  public List<ReptilianSwitchInteraction> reptilianSwitches;

  public bool[] tableOfTruth;

  public void onInteraction()
  {
    for (int i = 0; i < tableOfTruth.Length; i++)
    {
      if (reptilianSwitches[i].isActive != tableOfTruth[i])
      {
        return;
      }
    }
    foreach (ReptilianSwitchInteraction switchInteraction in reptilianSwitches)
    {
      switchInteraction.isDisabled = true;
    }
    FinishObjective();
  }
}
