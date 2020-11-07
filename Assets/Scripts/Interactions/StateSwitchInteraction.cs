using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class StateSwitchInteraction : MonoBehaviour, IInteractableObject
{
  private StateManager stateManager;

  private void Start()
  {
    gameObject.layer = 8;
    stateManager = GetComponent<StateManager>();
  }

  public bool isDisabled { get; set; }

  public void Interact()
  {
    stateManager.SwitchObjective();
  }

  public bool IsUsed()
  {
    return false;
  }
}
