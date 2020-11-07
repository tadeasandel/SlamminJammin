using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonZoom : MonoBehaviour
{
    
    public InteractionClockHand dezoomScr;
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
}
