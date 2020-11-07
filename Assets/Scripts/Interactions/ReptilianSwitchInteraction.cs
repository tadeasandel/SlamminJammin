using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptilianSwitchInteraction : SwitchInteraction
{
  ReptilianSubObjective reptilianSubObjective;

  public override void Awake()
  {
    base.Awake();
    reptilianSubObjective = GetComponentInParent<ReptilianSubObjective>();
  }

  public override void Interact()
  {
    base.Interact();
    reptilianSubObjective.onInteraction();
  }
}
