using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonZoom : MonoBehaviour
{
  public List<GameObject> btn;

  public InteractionClockHand clockInteraction;

  public GameObject checkHandOne;

  public GameObject checkHandTwo;
  public bool isDone;
  public int kolo;

  public AudioSource mainSoundAudio;
  public AudioClip click;

  public void Dezoom()
  {
    if (!isDone)
    {
      checkHandOne.transform.rotation = new Quaternion(checkHandOne.transform.rotation.x, checkHandOne.transform.rotation.y, 0, checkHandOne.transform.rotation.w);
    }
    clockInteraction.ZoomBack();
  }

  public void ok()
  {
    if (kolo == 1)
    {
      if (checkHandOne.transform.rotation.z < -0.417f && checkHandOne.transform.rotation.z > -0.6f || checkHandOne.transform.rotation.z > 0.417f && checkHandOne.transform.rotation.z < 0.6f)
      {
        for (int i = 0; i < btn.Count - 1; i++)
        {
          btn[i].SetActive(false);
        }
        isDone = true;
        clockInteraction.isDone = isDone;
        clockInteraction.isDisabled = isDone;
      }
    }
    else // druhe kolo - to s šestkou
    {
      if (checkHandOne.transform.localEulerAngles.z < 190 && checkHandOne.transform.localEulerAngles.z > 170)
      {
        for (int i = 0; i < btn.Count - 1; i++)
        {
          btn[i].SetActive(false);
        }
        isDone = true;
        clockInteraction.isDone = isDone;
        clockInteraction.isDisabled = isDone;
      }
    }
  }

  public void Zobraz()
  {
    for (int i = 0; i < btn.Count; i++)
    {
      btn[i].SetActive(true);
    }
  }
}
