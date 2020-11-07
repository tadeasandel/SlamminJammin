using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionClockHand : MonoBehaviour, IInteractableObject
{
  public float RotationSpeed = 55;
  public bool isActive;
  public CameraRotation cameraRotation;
  public float minimalRotation;
  public float maximalRotation;
  void Awake()
  {
    cameraRotation = GameObject.Find("Player").GetComponent<CameraRotation>();
  }
  public void Interact()
  {
    isActive = !isActive;
    cameraRotation.isRotationPaused = isActive;
  }

  public bool IsUsed()
  {
    return false;

  }

  void Update()
  {
    if (isActive)
    {
      transform.Rotate(0, 0, (Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), Space.World);
    }
    if (isActive && Input.GetMouseButtonUp(0))
    {
      isActive = false;
      cameraRotation.isRotationPaused = isActive;
    }
    if (transform.localRotation.z < minimalRotation && transform.localRotation.z > maximalRotation)
    {
      Debug.Log("jop");
    }
  }
}
