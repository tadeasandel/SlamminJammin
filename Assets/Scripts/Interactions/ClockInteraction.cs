using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockInteraction : MonoBehaviour, IInteractableObject
{
  

    public void Interact()
    {
        Debug.LogWarning("interakce");
        throw new System.NotImplementedException();
        //sem se zpět vrati hračova hodnota
        
    }

    public bool IsUsed()
    {
        Debug.LogWarning("used");
      //throw new System.NotImplementedException();
        return false;
    }


}
