using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RossWellObjective : MainObjectiveBase
{
  public Material materialOnFinished;

  public MeshRenderer meshToChange;

  public override void FinishObjective()
  {
    meshToChange.material = materialOnFinished;
    base.FinishObjective();
  }
}
