using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSwitchButtonInteraction : SwitchInteraction
{
  SpriteRenderer sprite;

  public override void Awake()
  {
    base.Awake();
    sprite = GetComponent<SpriteRenderer>();
    sprite.enabled = isActive;
  }

  public override void Interact()
  {
    base.Interact();
    sprite.enabled = isActive;
  }
}
