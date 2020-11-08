using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RecorderSideObjective : ObjectiveBase
{
  public AudioSource audioSource;

  public GameObject onCompletionTrigger;
  public AudioClip onCompletionClip;

  public List<RecorderSwitchInteraction> recorderSwitches;

  public GameObject wheelOne;
  public GameObject wheelTwo;

  public bool[] tableOfTruth;

  public float rotationSpeed;

  public AudioClip[] clips;

  public override void InitObjective(MainObjectiveBase mainObjectiveBase)
  {
    base.InitObjective(mainObjectiveBase);
    onCompletionTrigger.SetActive(false);
    audioSource = GetComponent<AudioSource>();
  }

  public void onInteraction()
  {
    for (int i = 0; i < tableOfTruth.Length; i++)
    {
      if (recorderSwitches[i].isActive != tableOfTruth[i])
      {
        return;
      }
    }
    foreach (RecorderSwitchInteraction switchInteraction in recorderSwitches)
    {
      switchInteraction.isDisabled = true;
    }
    FinishObjective();
  }

  public AudioClip GetRandomClip()
  {
    return clips[Random.Range(0, clips.Length)];
  }

  public override void FinishObjective()
  {
    isObjectiveDone = true;
    onCompletionTrigger.SetActive(true);
    audioSource.PlayOneShot(onCompletionClip);
    StartCoroutine(RotateWheels());
  }

  private IEnumerator RotateWheels()
  {
    while (audioSource.isPlaying)
    {
      wheelOne.transform.Rotate((rotationSpeed * Time.deltaTime), 0, 0, Space.World);
      wheelTwo.transform.Rotate((-rotationSpeed * Time.deltaTime), 0, 0, Space.World);
      yield return null;
    }
  }
}
