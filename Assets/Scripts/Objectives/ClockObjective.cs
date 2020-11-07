using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClockInteraction))]
public class ClockObjective : ObjectiveBase
{
  ClockInteraction clockInteraction;

  public SpriteRenderer clockOne;
  public SpriteRenderer clockTwo;
  public SpriteRenderer clockThree;
  public SpriteRenderer clockFour;

  public HourTime correctClockTime;

  public override void EnableObjective(Action onObjectiveCompletedCallback)
  {
    base.EnableObjective(onObjectiveCompletedCallback);
    clockInteraction = GetComponent<ClockInteraction>();
  }

    public bool IsTimeCorect()
    {
        if (correctClockTime.firstDigit == int.Parse(clockOne.sprite.name) &&
            correctClockTime.secondDigit == int.Parse(clockTwo.sprite.name) &&
            correctClockTime.thirdDigit == int.Parse(clockThree.sprite.name) &&
            correctClockTime.fourthDigit == int.Parse(clockFour.sprite.name))
        {
            Debug.LogWarning("spravna hodnota hodin");
            return true;
        }
        return false;
        
        
            
    
    }


}

[System.Serializable]
public struct HourTime
{
  public float firstDigit;
  public float secondDigit;
  public float thirdDigit;
  public float fourthDigit;

  public HourTime(float firstDigit, float secondDigit, float thirdDigit, float fourthDigit)
  {
    this.firstDigit = firstDigit;
    this.secondDigit = secondDigit;
    this.thirdDigit = thirdDigit;
    this.fourthDigit = fourthDigit;
  }
}

