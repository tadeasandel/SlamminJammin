using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class StateSwitchInteraction : MonoBehaviour, IInteractableObject
{
  private StateManager stateManager;

  private void Start()
  {
    stateManager = GetComponent<StateManager>();
    isReady = true;
  }

  public bool isReady { get; set; }

  public void Interact()
  {
    stateManager.SwitchObjective();
  }

  public bool IsUsed()
  {
    return false;
  }
}
