using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteraction : InteractionBase
{
  public bool isActive;

  public override void Interact()
  {
    base.Interact();
    isActive = !isActive;
  }
}
