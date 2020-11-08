using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorInteraction : InteractionBase
{
  public AudioSource audioSource;
  public AudioClip doorKnock;

  private ObjectivesManager objectivesManager;

  public GameObject CameraLookTarget;
  public GameObject CameraEnd;

  public float zoomSpeed;

  public override void Awake()
  {
    base.Awake();
    audioSource = GetComponent<AudioSource>();
    objectivesManager = FindObjectOfType<ObjectivesManager>();
  }

  public override void Interact()
  {
    base.Interact();
    if (objectivesManager.isGameFinished)
    {
      FinishGame();
      return;
    }
    if (!audioSource.isPlaying)
    {
      audioSource.PlayOneShot(doorKnock);
    }
  }

  private void FinishGame()
  {
    StartCoroutine(FinishGameCor());
  }

  public IEnumerator FinishGameCor()
  {
    Vector3 direction;
    float distance = float.MaxValue;
    while (distance >= 1)
    {
      distance = Vector3.Distance(CameraEnd.transform.position, Camera.main.transform.position);
      direction = CameraEnd.transform.position - Camera.main.transform.position;
      direction = direction.normalized;
      Camera.main.transform.LookAt(CameraLookTarget.transform.position);
      Camera.main.transform.Translate(direction * Time.deltaTime * zoomSpeed);
      yield return null;
    }
  }
}
