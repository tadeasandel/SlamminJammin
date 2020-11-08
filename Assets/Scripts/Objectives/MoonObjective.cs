using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonObjective : MainObjectiveBase
{
  public RecorderSideObjective sideObjective;

  public override void InitObjective(ObjectivesManager objectivesManager)
  {
    base.InitObjective(objectivesManager);
    sideObjective.InitObjective(this);
  }

  public override void FinishObjective()
  {
    base.FinishObjective();
  }
}
