using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteraction : MonoBehaviour, IInteractableObject
{
  public bool isActive;

  public void Interact()
  {
    isActive = !isActive;
    throw new System.NotImplementedException();
  }

  public bool IsUsed()
  {
    return false;
  }
}
