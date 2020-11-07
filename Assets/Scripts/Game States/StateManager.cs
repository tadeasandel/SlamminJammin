using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateSwitchInteraction))]
public class StateManager : MonoBehaviour
{
  public List<List<GameObject>> gameStates;

  [Range(0,2)]
  int currentStateIndex = 0;

  public void StartGame()
  {
    SetStateVisibility(currentStateIndex, true);
  }

  public void SetStateVisibility(int index, bool isVisible)
  {
    foreach (GameObject objectToSet in gameStates[index])
    {
      objectToSet.SetActive(isVisible);
    }
  }

  public void SwitchObjective()
  {
    SetStateVisibility(currentStateIndex, false);
    if (currentStateIndex == 2)
    {
      currentStateIndex = 0;
    }
    else
    {
      currentStateIndex++;
    }
    SetStateVisibility(currentStateIndex, true);
  }
}
