using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour, IInteractableObject
{
  public bool isActive;

  public void Interact()
  {
       Debug.LogError("setting state to " + isActive);
        isActive = !isActive;
      
       
  }

  public bool IsUsed()
  {
    return false;
  }
}
