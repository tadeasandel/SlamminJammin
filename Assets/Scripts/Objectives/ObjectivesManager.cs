using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
  public List<MainObjectiveBase> mainObjectives;

  StateManager stateManager;

  void Start()
  {
    foreach (MainObjectiveBase objective in mainObjectives)
    {
      objective.InitObjective(this);
    }
    stateManager = FindObjectOfType<StateManager>();
    stateManager.StartGame();
  }

  public void CheckObjectives()
  {
    foreach (MainObjectiveBase mainObjective in mainObjectives)
    {
      if (!mainObjective.isMainObjectiveCompleted)
      {
        return;
      }
    }
    FinishGame();
  }

  public void FinishGame()
  {
    Debug.LogError("game is finished");
  }
}
