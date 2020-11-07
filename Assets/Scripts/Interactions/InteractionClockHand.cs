﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractionClockHand : InteractionBase
{
  public float RotationSpeed = 55;
  public bool isActive;
  public CameraRotation cameraRotation;
  public MovementController movementController;
  protected Rigidbody rb;
  public float minimalRotation;
  public float maximalRotation;

  GameObject Maincamera;
  GameObject cameraTarget;
  public float timeCorountine;
  public List<Image> btn;

  public bool isZoomedIn;

  void Awake()
  {
    cameraRotation = GameObject.Find("Player").GetComponent<CameraRotation>();
    movementController = GameObject.Find("Player").GetComponent<MovementController>();
    rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    Maincamera = GameObject.Find("Main Camera");
    cameraTarget = GameObject.Find("CameraZoomPosition");
  }

  public override void Interact()
  {
    if(isActive) { return; }
    base.Interact();
    isActive = !isActive;
    isReady = false;
    StartCoroutine(Switch());

  }
  IEnumerator Switch()
  {
    yield return StartCoroutine(CameraZoom(Maincamera, cameraTarget, timeCorountine));
    StartCoroutine(FadeOut(1, 0));


  }
  IEnumerator FadeOut(float startValue, float endValue)
  {
    Debug.LogError("probehlo_spusteni Fa");

    float currentValue = startValue;
    Debug.LogError(currentValue);
    while (currentValue >= endValue)
    {
      currentValue -= Time.deltaTime;



      for (int i = 0; i < 4; i++)
      {
        btn[i].color = new Color(btn[i].color.r, btn[i].color.g, btn[i].color.b, currentValue);

      }
      yield return null;
    }



  }


  public override bool IsUsed()
  {
    return false;
  }

  IEnumerator CameraZoom(GameObject startPosition, GameObject endPosition, float time)
  {
    Debug.LogError("probehlo_spusteni");
    cameraRotation.isRotationPaused = isActive;
    movementController.isMovementPaused = isActive;
    rb.constraints = RigidbodyConstraints.FreezeRotationY;
    UnityEngine.Cursor.lockState = CursorLockMode.Confined;


    Transform currentTransform = startPosition.transform;
    while (!isZoomedIn)
    {
      currentTransform.position = new Vector3(Mathf.Lerp(currentTransform.position.x, endPosition.transform.position.x, time),
        Mathf.Lerp(currentTransform.position.y, endPosition.transform.position.y, time),
        Mathf.Lerp(currentTransform.position.z, endPosition.transform.position.z, time));
      currentTransform.rotation = Quaternion.Euler(Mathf.Lerp(currentTransform.rotation.x, endPosition.transform.rotation.x, time),
  Mathf.Lerp(currentTransform.rotation.y, endPosition.transform.rotation.y, time),
  Mathf.Lerp(currentTransform.rotation.z, endPosition.transform.rotation.z, time));
      yield return null;
    }
    Debug.LogError("cor finished");


  }

  void Update()
  {
    if (isActive)
    {
      //  transform.Rotate(0, 0, (Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), Space.World);
    }

    /*/if (isActive && Input.GetMouseButtonUp(0))
    {
      isActive = false;
      cameraRotation.isRotationPaused = isActive;
    }
    if (transform.localRotation.z < minimalRotation && transform.localRotation.z > maximalRotation)
    {
      Debug.Log("jop");
    }*/
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject == Camera.main.gameObject)
    {
      Debug.LogError("trigger enter with camera zoom pos");
      isZoomedIn = true;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject == Camera.main.gameObject)
    {
      isZoomedIn = false;
    }
  }
}
