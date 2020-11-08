using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
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

  public UIbuttonZoom uIbuttonZoom;

  GameObject Maincamera;
  public GameObject cameraTarget;
  public float timeCorountine;
  public List<Image> btn;

  public float transitionTime;

  public Vector3 cachedCameraPosition;
  public Quaternion cachedCameraRotation;
  public Transform lookTarget;
  public bool isDone;
  public int hodiny;

  public float speed = 1.05f;
  public float distanceLimit = 1.0f;

  public override void Awake()
  {
    base.Awake();
    cameraRotation = GameObject.Find("Player").GetComponent<CameraRotation>();
    movementController = GameObject.Find("Player").GetComponent<MovementController>();
    rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    Maincamera = GameObject.Find("Main Camera");
  }

  public override void Interact()
  {
    if (isActive) { return; }
    base.Interact();
    isActive = true;
    isDisabled = true;
    StartCoroutine(Switch());
  }

  IEnumerator Switch()
  {
    yield return StartCoroutine(CameraZoom(Maincamera.transform, cameraTarget.transform));
    StartCoroutine(FadeIn(0, 1));
  }


  IEnumerator FadeIn(float startValue, float endValue)
  {
    float currentValue = startValue;

    while (currentValue <= endValue)
    {
      currentValue += Time.deltaTime;

      for (int i = 0; i < btn.Count; i++)
      {
        btn[i].color = new Color(btn[i].color.r, btn[i].color.g, btn[i].color.b, currentValue);
      }
      yield return null;
    }
  }



  IEnumerator FadeOut(float startValue, float endValue)
  {
    float currentValue = startValue;

    while (currentValue >= endValue)
    {
      currentValue -= Time.deltaTime;

      for (int i = 0; i < btn.Count; i++)
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

  IEnumerator CameraZoom(Transform startPosition, Transform endPosition)
  {
    cameraRotation.isRotationPaused = isActive;
    movementController.isMovementPaused = isActive;
    rb.freezeRotation = true;
    rb.constraints = RigidbodyConstraints.FreezeAll;
    UnityEngine.Cursor.lockState = CursorLockMode.None;

    cachedCameraPosition = startPosition.position;
    cachedCameraRotation = startPosition.rotation;
    float distance = float.MaxValue;
    while (distance > distanceLimit)
    {
      Vector3 direction = cameraTarget.transform.position - startPosition.position;
      direction = direction.normalized;

      distance = Vector3.Distance(endPosition.transform.position, startPosition.position);
      startPosition.Translate(direction * Time.deltaTime * speed);
      startPosition.LookAt(lookTarget);
      yield return null;
    }
    uIbuttonZoom.clock = hodiny;
    uIbuttonZoom.selectClock();
    uIbuttonZoom.Zobraz();
  }

  public void ZoomBack()
  {
    foreach (Image button in btn)
    {
      button.color = new Color(button.color.r, button.color.g, button.color.b, 0);
      button.gameObject.SetActive(false);
    }
    StartCoroutine(ZoomBack(Maincamera.transform, cachedCameraPosition, cachedCameraRotation));
  }

  IEnumerator ZoomBack(Transform startPosition, Vector3 endPosition, Quaternion rotation)
  {
    cameraRotation.isRotationPaused = isActive;
    movementController.isMovementPaused = isActive;
    rb.freezeRotation = true;
    rb.constraints = RigidbodyConstraints.FreezeAll;

    cachedCameraPosition = startPosition.position;
    cachedCameraRotation = startPosition.rotation;
    float distance = float.MaxValue;
    while (distance > distanceLimit)
    {
      Vector3 direction = cachedCameraPosition - startPosition.position;
      direction = direction.normalized;

      distance = Vector3.Distance(cachedCameraPosition, startPosition.position);
      startPosition.Translate(direction * Time.deltaTime * speed);
      yield return null;
    }
    Debug.LogError("cor finished");

    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
    isActive = false;
    isDisabled = false;
    startPosition.localPosition = new Vector3(0,0,0);
    startPosition.rotation = Quaternion.Euler(0,0,0);

    cameraRotation.isRotationPaused = false;
    movementController.isMovementPaused = false;
    Cursor.lockState = CursorLockMode.Locked;
  }




}
