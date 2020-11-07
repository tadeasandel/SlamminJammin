using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteraction : MonoBehaviour, IInteractableObject
{
  public bool isActive;

    public void Interact()
    {
        //Debug.LogError("setting state to " + isActive);
        isActive = !isActive;
        throw new System.NotImplementedException();
       
      
       
  }

  public bool IsUsed()
  {
    return false;
  }
}
