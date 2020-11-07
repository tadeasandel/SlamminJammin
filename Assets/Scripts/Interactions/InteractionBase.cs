using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour, IInteractableObject
{

  public virtual void Awake()
  {
    gameObject.layer = 8;
  }

  public virtual bool isReady { get; set; }

  public virtual void Interact()
  {
    if (!isReady) { return; }
  }

  public virtual bool IsUsed()
  {
    return false;
  }
}
