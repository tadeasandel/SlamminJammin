using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptilianSwitchInteraction : SwitchInteraction
{
  ReptilianSubObjective reptilianSubObjective;
  SpriteRenderer sprite;

  public override void Awake()
  {
    base.Awake();
    reptilianSubObjective = GetComponentInParent<ReptilianSubObjective>();
    sprite = GetComponent<SpriteRenderer>();
    sprite.enabled = isActive;
  }

  public override void Interact()
  {
    base.Interact();
    sprite.enabled = isActive;
    reptilianSubObjective.onInteraction();
  }
}
