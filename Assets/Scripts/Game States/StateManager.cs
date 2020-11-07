using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateSwitchInteraction))]
public class StateManager : MonoBehaviour
{
  public List<GameObject> firstState;
  public List<GameObject> secondState;
  public List<GameObject> thirdState;

  private List<List<GameObject>> gameStates;

  [Range(0,2)]
  int currentStateIndex = 0;

  public void StartGame()
  {
    gameStates = new List<List<GameObject>>();
    gameStates.Add(firstState);
    gameStates.Add(secondState);
    gameStates.Add(thirdState);
    SetStateVisibility(currentStateIndex, true);
    SetStateVisibility(1, false);
    SetStateVisibility(2, false);
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
