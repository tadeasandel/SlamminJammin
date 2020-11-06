using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractionController : MonoBehaviour
{
  public float reachDistance;

  void Update()
  {
    IInteractableObject currentInteraction = GetCurrentInteraction();
    if (currentInteraction != null)
    {
      Debug.LogError("got interaction " + currentInteraction.ToString());
      if (Input.GetKeyDown(KeyCode.Mouse0) && !currentInteraction.IsUsed())
      {
        currentInteraction.Interact();
      }
    }
  }

  private IInteractableObject GetCurrentInteraction()
  {
    RaycastHit hit;
    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance))
    {
      IInteractableObject rayCastableObject = hit.transform.GetComponent<IInteractableObject>();
      if (rayCastableObject != null)
      {
        return rayCastableObject;
      }
    }
    return null;
  }
}
