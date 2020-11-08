using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptilianObjective : MainObjectiveBase
{
  public Material materialOnFinished;

  public MeshRenderer meshToChange;

  public StartAnimation startAnimation;

  public override void InitObjective(ObjectivesManager objectivesManager)
  {
    base.InitObjective(objectivesManager);
  }

  public override void FinishObjective()
  {
    meshToChange.material = materialOnFinished;
    base.FinishObjective();
  }
}
