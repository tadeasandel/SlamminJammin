using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInteractionController : MonoBehaviour
{
  public float reachDistance;

  public Image HandInteractable;
  public Image HandOnInteracted;

  public bool canInteract = true;

  public LayerMask raycastLayer;

  public float longHandDisplayTime;

  private void Start()
  {
    HandOnInteracted.gameObject.SetActive(false);
  }

  void Update()
  {
    IInteractableObject currentInteraction = GetCurrentInteraction();
    if (currentInteraction != null && currentInteraction.isReady)
    {
      if (canInteract)
      {
        HandInteractable.gameObject.SetActive(true);
      }

      if (Input.GetKeyDown(KeyCode.Mouse0) && !currentInteraction.IsUsed() && canInteract)
      {
        currentInteraction.Interact();
        StartCoroutine(ShowInteractHandThenHide());
      }
    }
    else
    {
      HandInteractable.gameObject.SetActive(false);
    }
  }

  private IEnumerator ShowInteractHandThenHide()
  {
    canInteract = false;
    HandInteractable.gameObject.SetActive(false);
    HandOnInteracted.gameObject.SetActive(true);
    yield return new WaitForSecondsRealtime(longHandDisplayTime);
    HandOnInteracted.gameObject.SetActive(false);
    canInteract = true;
  }

  private IInteractableObject GetCurrentInteraction()
  {
    RaycastHit hit;
    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance, raycastLayer))
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
