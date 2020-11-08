using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMiniButton : MonoBehaviour
{
   
    public GameObject Sipka;

    public int clock;

    public float RotationSpeed;
    public float Distance;
    public UIbuttonZoom parent;


    private void Start()
    {
        parent = GetComponentInParent<UIbuttonZoom>();
       


    }

    void Update()
    {
        if (!ispressed)
            return;
        Sipka.transform.Rotate(0, 0, (Distance * RotationSpeed * Time.deltaTime), Space.World);
        Debug.Log("Pressed");
    }
    bool ispressed = false;
    public void OnPointerDown()
    {
        parent.mainSoundAudio.Play();
        ispressed = true;
    }

    public void OnPointerUp()
    {
        ispressed = false;
        parent.mainSoundAudio.Stop();
    }



    public void Doleva()
    {
        Debug.LogWarning("Doleve");
        Sipka.transform.Rotate(0, 0, (Distance * RotationSpeed * Time.deltaTime), Space.World);
    }

 
}
