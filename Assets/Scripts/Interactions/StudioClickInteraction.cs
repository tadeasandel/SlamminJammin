using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudioClickInteraction : InteractionBase
{
  public bool isDone;

  MoonStudioObjective moonStudioObjective;

  public override void Awake()
  {
    base.Awake();
    moonStudioObjective = GetComponentInParent<MoonStudioObjective>();
  }

  public override void Interact()
  {
    base.Interact();
    isDone = true;
    isDisabled = true;
    moonStudioObjective.onInteraction();
  }
}
