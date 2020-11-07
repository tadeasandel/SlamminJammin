using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockButtonInteraction : InteractionBase
{
  public SpriteRenderer sprite;
  public List<Sprite> changed_sprite;

  public bool positive;

  public override void Interact()
  {
    base.Interact();
    int number = int.Parse(sprite.sprite.name);
    if (positive)
    {
      if (number < 9)
      {
        number++;
      }
      else
      {
        number = 1;
      }
    }
    else
    {
      if (number > 1)
      {
        number--;
      }
      else
      {
        number = 9;
      }
    }
    sprite.sprite = changed_sprite[number - 1];
  }

  public bool IsUsed()
  {
    return false;
  }
}
