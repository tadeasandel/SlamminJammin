using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockInteraction : InteractionBase
{
  
  public override bool isReady { get; set; }

    public override void Interact()
    {
    base.Interact();
        Debug.LogWarning("interakce");
        //sem se zpět vrati hračova hodnota
        
    }

    public override bool IsUsed()
    {
        Debug.LogWarning("used");
        return false;
    }


}
