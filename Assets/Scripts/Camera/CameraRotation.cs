using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
  public Transform cameraTransform;

  public bool isRotationPaused; //muj pridavek

  public float mouseSensitivity = 10.0f;

  private float xRotation;
  private float yRotation;

  void Update()
  {
    if (isRotationPaused) { return; }
    xRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
    yRotation += Input.GetAxis("Mouse X") * mouseSensitivity;

    xRotation = Mathf.Clamp(xRotation, -60, 60);

    cameraTransform.localRotation = Quaternion.Euler(-xRotation, cameraTransform.localRotation.y, cameraTransform.localRotation.z);

    transform.rotation = Quaternion.Euler(transform.rotation.y, yRotation, transform.rotation.z);
  }
}
