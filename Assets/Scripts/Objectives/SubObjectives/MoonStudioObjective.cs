using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonStudioObjective : ObjectiveBase
{
  public List<StudioClickInteraction> StudioClicks;

  public void onInteraction()
  {
    foreach (StudioClickInteraction click in StudioClicks)
    {
      if (!click.isDone)
      {
        return;
      }
    }
    foreach (StudioClickInteraction switchInteraction in StudioClicks)
    {
      switchInteraction.isDisabled = true;
    }
    FinishObjective();
  }
}
