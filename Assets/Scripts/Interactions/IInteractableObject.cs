using UnityEngine;

public interface IInteractableObject
{
  bool isDisabled { get; set; }

  bool IsUsed();
  void Interact();
}
