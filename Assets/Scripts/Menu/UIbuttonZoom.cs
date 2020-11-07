using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonZoom : MonoBehaviour
{
    public List<GameObject> btn;
    public InteractionClockHand dezoomScr;
    public GameObject checkHandOne;
    public GameObject checkHandTwo;

    // Start is called before the first frame update
    void Start()
    {
        dezoomScr = GameObject.Find("ClockHandObjective").GetComponent<InteractionClockHand>(); ;

    }

    // Update is called once per frame
    public void Dezoom()
    {
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

            }
          

        }
    
    
    
    }
    private void Update()
    {
        Debug.LogWarning("pozice ručičky" + checkHandTwo.transform.rotation.z);
    }

}
