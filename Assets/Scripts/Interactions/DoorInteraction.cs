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

  public GameObject endGameScreen;
  public GameObject objectives;

  public float zoomSpeed;
  public float delay;

  public override void Awake()
  {
    base.Awake();
    endGameScreen.SetActive(false);
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
    StartCoroutine(WaitThenShowEnd());
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

  public IEnumerator WaitThenShowEnd()
  {
    float currentTime = 0;
    while (currentTime <= delay)
    {
      currentTime += Time.deltaTime;
      yield return null;
    }
    endGameScreen.SetActive(true);
    objectives.SetActive(false);
  }
}
