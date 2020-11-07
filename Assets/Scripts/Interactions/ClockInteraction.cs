using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockInteraction : MonoBehaviour, IInteractableObject
{
  

    public void Interact()
    {
        Debug.LogWarning("interakce");
        //sem se zpět vrati hračova hodnota
        
    }

    public bool IsUsed()
    {
        Debug.LogWarning("used");
        return false;
    }


}
