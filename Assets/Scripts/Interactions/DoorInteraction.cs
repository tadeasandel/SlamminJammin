using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorInteraction : InteractionBase
{
  public AudioSource audioSource;
  public AudioClip doorKnock;

  public override void Awake()
  {
    base.Awake();
    audioSource = GetComponent<AudioSource>();
  }

  public override void Interact()
  {
    base.Interact();
    if (!audioSource.isPlaying)
    {
      audioSource.PlayOneShot(doorKnock);
    }
  }
}
