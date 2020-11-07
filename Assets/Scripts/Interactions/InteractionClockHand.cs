using System.Collections;
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

  public float transitionTime = 1;

    public Vector3 CameraSavePosition;
    public Quaternion CameraSaveRotation;

    

    public override void Awake()
  {
    base.Awake();
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
    isActive = true;
    isReady = false;
    StartCoroutine(Switch());

  }
  IEnumerator Switch()
  {
        transitionTime = transitionTime * Vector3.Distance(cameraTarget.transform.position, Maincamera.transform.position);
    yield return StartCoroutine(CameraZoom(Maincamera, cameraTarget, timeCorountine, transitionTime));
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

  IEnumerator CameraZoom(GameObject startPosition, GameObject endPosition, float timeDelay, float coroutineDelay)
  {
    Debug.LogError("probehlo_spusteni");
    cameraRotation.isRotationPaused = isActive;
    movementController.isMovementPaused = isActive;
    rb.constraints = RigidbodyConstraints.FreezeRotationY;
    UnityEngine.Cursor.lockState = CursorLockMode.Confined;


    Transform currentTransform = startPosition.transform;
        CameraSavePosition = startPosition.transform.position;
        CameraSaveRotation = startPosition.transform.rotation;
        float currentTime = 0;
    while (coroutineDelay >= currentTime)
    {
      currentTransform.position = new Vector3(Mathf.Lerp(currentTransform.position.x, endPosition.transform.position.x, timeDelay),
        Mathf.Lerp(currentTransform.position.y, endPosition.transform.position.y, timeDelay),
        Mathf.Lerp(currentTransform.position.z, endPosition.transform.position.z, timeDelay));
      currentTransform.rotation = Quaternion.Euler(Mathf.Lerp(currentTransform.rotation.x, endPosition.transform.rotation.x, timeDelay),
  Mathf.Lerp(currentTransform.rotation.y, endPosition.transform.rotation.y, timeDelay),
  Mathf.Lerp(currentTransform.rotation.z, endPosition.transform.rotation.z, timeDelay));
      currentTime += Time.deltaTime;
      yield return null;
    }
    Debug.LogError("cor finished");


  }

    public void Dezoom()
    {
        for (int i = 0; i < btn.Count; i++)
        {
            btn[i].color = new Color(btn[i].color.r, btn[i].color.g, btn[i].color.b, 0);

        }
        StartCoroutine(CameraDeZoom(Maincamera, CameraSavePosition,CameraSaveRotation, timeCorountine, transitionTime));
    }

    IEnumerator CameraDeZoom(GameObject startPosition, Vector3 endPosition, Quaternion rotation, float timeDelay, float coroutineDelay)
    {
        Transform currentTransform = startPosition.transform;
        float currentTime = 0;
        while (coroutineDelay >= currentTime)
        {
            currentTransform.position = new Vector3(Mathf.Lerp(currentTransform.position.x, endPosition.x, timeDelay),
              Mathf.Lerp(currentTransform.position.y, endPosition.y, timeDelay),
              Mathf.Lerp(currentTransform.position.z, endPosition.z, timeDelay));
            currentTransform.rotation = Quaternion.Euler(Mathf.Lerp(currentTransform.rotation.x, rotation.x, timeDelay),
        Mathf.Lerp(currentTransform.rotation.y, rotation.y, timeDelay),
        Mathf.Lerp(currentTransform.rotation.z, rotation.z, timeDelay));
            currentTime += Time.deltaTime;
            yield return null;
        }

        isActive = false;
        isReady = true ;

        currentTransform.transform.position = CameraSavePosition;
        Debug.LogError("pZapnutíOdzoomui");
        cameraRotation.isRotationPaused = false;
        movementController.isMovementPaused = false;

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        yield return null;

    }

    



}
