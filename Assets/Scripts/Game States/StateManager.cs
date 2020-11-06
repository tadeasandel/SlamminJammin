using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
  public List<StateBase> gameStates;

  int currentStateIndex = 0;

  private void Start()
  {
    gameStates[currentStateIndex].StartState(TransitionToNextState);
  }

  public void TransitionToNextState()
  {
    if (gameStates.Count <= currentStateIndex + 1)
    {
      FinishGame();
      return;
    }
    gameStates[currentStateIndex].EndState(() =>
    {
      gameStates[++currentStateIndex].StartState(TransitionToNextState);
    });
  }

  public void FinishGame()
  {

  }
}
