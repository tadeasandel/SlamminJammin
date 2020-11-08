using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonZoom : MonoBehaviour
{
    public List<GameObject> btn;
    
    public InteractionClockHand dezoomScr;

    
    public GameObject checkHandOne;

    public GameObject checkHandTwo;
    public bool isDone;
    public int kolo;

    public AudioSource mainSoundAudio;
    public AudioClip click;




    // Update is called once per frame
    public void Dezoom()
    {
        if (!isDone)
        {
            checkHandOne.transform.rotation = new Quaternion(checkHandOne.transform.rotation.x, checkHandOne.transform.rotation.y,0, checkHandOne.transform.rotation.w) ;
            checkHandTwo.transform.rotation = new Quaternion(checkHandTwo.transform.rotation.x, checkHandTwo.transform.rotation.y, 0, checkHandTwo.transform.rotation.w);

        }
        dezoomScr.ZoomBack();
    }

    public void ok()
    {
        Debug.LogWarning("pozice ručičky klask" + checkHandOne.transform.localEulerAngles.z);
        Debug.LogWarning("pozice ručičky klask" + checkHandOne.transform.localRotation.z);

        if (kolo==1)
        {
            if (checkHandOne.transform.rotation.z < -0.417f && checkHandOne.transform.rotation.z > -0.6f || checkHandOne.transform.rotation.z > 0.417f && checkHandOne.transform.rotation.z < 0.6f)
            {
                if (checkHandTwo.transform.rotation.z > -0.095f && checkHandTwo.transform.rotation.z < -0.0722f || checkHandTwo.transform.rotation.z < 0.095f && checkHandTwo.transform.rotation.z > -0.0722)
                {
                    Debug.LogWarning("pozice ručičky" + checkHandOne.transform.rotation.z);
                    for (int i = 0; i < btn.Count - 1; i++)
                    {
                        btn[i].SetActive(false);
                    }
                    isDone = true;
                    dezoomScr.isDone = isDone;


                }


            }

        }
        else // druhe kolo - to s šestkou
        {
            if (checkHandOne.transform.localEulerAngles.z < 190 && checkHandOne.transform.localEulerAngles.z > 170 )
            {
                if (checkHandTwo.transform.rotation.z > -0.095f && checkHandTwo.transform.rotation.z < -0.0722f || checkHandTwo.transform.rotation.z < 0.095f && checkHandTwo.transform.rotation.z > -0.0722)
                {
                    Debug.LogWarning("pozice ručičky" + checkHandOne.transform.rotation.z);
                    for (int i = 0; i < btn.Count - 1; i++)
                    {
                        btn[i].SetActive(false);
                    }
                    isDone = true;
                    dezoomScr.isDone = isDone;


                }


            }

        }

     


        
       



    }
    private void Update()
    {
      //  Debug.LogWarning("pozice ručičkyVelke" + checkHandTwo.transform.rotation.z);
      // Debug.LogWarning("pozice ručičkyMAle" + checkHandTwo.transform.rotation.z);
    }
    public void Zobraz() 
    {
        for (int i = 0; i < btn.Count; i++)
        {
            btn[i].SetActive(true);
        }
    }

}
