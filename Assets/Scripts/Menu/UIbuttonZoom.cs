using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonZoom : MonoBehaviour
{
    public List<GameObject> btn;
    public InteractionClockHand dezoomScr;
    public InteractionClockHand dezoomScr2;
    public GameObject checkHandOne;
    public GameObject checkHandTwo;
    public List<bool> isDone;
    public int arw;
    
    // Start is called before the first frame update
    private void Awake()
    {
        isDone[arw] = false;

    }
    void ARW()
    {
        
       

    }

    // Update is called once per frame
    public void Dezoom()
    {
        if (!isDone[arw])
        {
            checkHandOne.transform.rotation = new Quaternion(checkHandOne.transform.rotation.x, checkHandOne.transform.rotation.y,0, checkHandOne.transform.rotation.w) ;
            checkHandTwo.transform.rotation = new Quaternion(checkHandTwo.transform.rotation.x, checkHandTwo.transform.rotation.y, 0, checkHandTwo.transform.rotation.w);

        }
        dezoomScr.Dezoom();
    }

    public void ok()
    {
        if (checkHandOne.transform.rotation.z < -0.417f && checkHandOne.transform.rotation.z > -0.6f || checkHandOne.transform.rotation.z > 0.417f && checkHandOne.transform.rotation.z <0.6f )
        {
            if (checkHandTwo.transform.rotation.z > -0.095f && checkHandTwo.transform.rotation.z < -0.0722f || checkHandTwo.transform.rotation.z < 0.095f && checkHandTwo.transform.rotation.z > -0.0722)
            {
                Debug.LogWarning("pozice ručičky" + checkHandOne.transform.rotation.z);
                for (int i = 0; i < btn.Count; i++)
                {
                    btn[i].SetActive(false);
                }
                isDone[arw] = true;
                dezoomScr.isDone = isDone[arw];
            }
          

        }
    
    
    
    }
    private void Update()
    {
        Debug.LogWarning("pozice ručičky" + checkHandTwo.transform.rotation.z);
    }

}
