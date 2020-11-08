using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
  public void StartAnim()
  {
    GetComponent<Animation>().Play();
  }
}
