using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonZoom : MonoBehaviour
{
    public List<GameObject> btn;

    public List<InteractionClockHand> dezoomScrVar;
    public InteractionClockHand dezoomScr;

    public List<GameObject> checkHandOneVar;
    public GameObject checkHandOne;

    public List<GameObject> checkHandTwoVar;
    public GameObject checkHandTwo;


    public List<bool> isDone;
    public int clock;
   
    
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < 1; i++)
        {
            isDone[i] = false;
        }
       

    }

    public void selectClock()
    {
        dezoomScr = dezoomScrVar[clock];
        checkHandOne= checkHandOneVar[clock];
        checkHandTwo= checkHandTwoVar[clock];
    }
    

    // Update is called once per frame
    public void Dezoom()
    {
        if (!isDone[clock])
        {
            checkHandOne.transform.rotation = new Quaternion(checkHandOne.transform.rotation.x, checkHandOne.transform.rotation.y,0, checkHandOne.transform.rotation.w) ;
            checkHandTwo.transform.rotation = new Quaternion(checkHandTwo.transform.rotation.x, checkHandTwo.transform.rotation.y, 0, checkHandTwo.transform.rotation.w);

        }
        dezoomScr.Dezoom();
    }

    public void ok()
    {
        Debug.LogWarning("pozice ručičky klask" + checkHandOne.transform.rotation.z);
        Debug.LogWarning("pozice ručičky klask" + checkHandOne.transform.localRotation.z);

        if (clock==0)
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
                    isDone[clock] = true;
                    dezoomScr.isDone = isDone[clock];
                }


            }


        }
        else
        {
            if (checkHandTwo.transform.rotation.z > -0.095f && checkHandTwo.transform.rotation.z < -0.0722f || checkHandTwo.transform.rotation.z < 0.095f && checkHandTwo.transform.rotation.z > -0.0722)
            {
                if (checkHandOne.transform.rotation.z < -0.986f && checkHandOne.transform.rotation.z > -0.9999f)
                {//-0,9976247 -0,9690911
                    Debug.LogWarning("pozice ručičky" + checkHandOne.transform.rotation.z);
                    for (int i = 0; i < btn.Count - 1; i++)
                    {
                        btn[i].SetActive(false);
                    }
                    isDone[clock] = true;
                    dezoomScr.isDone = isDone[clock];
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
        for (int i = 0; i < btn.Count - 1; i++)
        {
            btn[i].SetActive(true);
        }
    }

}
