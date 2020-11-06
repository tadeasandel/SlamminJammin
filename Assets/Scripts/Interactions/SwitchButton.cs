using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour, IInteractableObject
{
  public bool currentState;

  public void Interact()
  {
    Debug.LogError("setting state to " + currentState);
    currentState = !currentState;
  }

  public bool IsUsed()
  {
    return false;
  }
}
