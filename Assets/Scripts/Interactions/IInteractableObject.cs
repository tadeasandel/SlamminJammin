using UnityEngine;

public interface IInteractableObject
{
  bool isReady { get; set; }

  bool IsUsed();
  void Interact();
}
