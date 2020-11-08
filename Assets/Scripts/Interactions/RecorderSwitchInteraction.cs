using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RecorderSwitchInteraction : SwitchInteraction
{
  public RecorderSideObjective parentObjective;

  RecorderSideObjective recorderSideObjective;
  SpriteRenderer sprite;

  public AudioSource audioSource;

  public override void Awake()
  {
    base.Awake();
    recorderSideObjective = GetComponentInParent<RecorderSideObjective>();
    sprite = GetComponent<SpriteRenderer>();
    sprite.enabled = isActive;
    audioSource = GetComponent<AudioSource>();
  }

  public override void Interact()
  {
    base.Interact();
    sprite.enabled = isActive;
    recorderSideObjective.onInteraction();
    audioSource.PlayOneShot(parentObjective.GetRandomClip());
  }
}
