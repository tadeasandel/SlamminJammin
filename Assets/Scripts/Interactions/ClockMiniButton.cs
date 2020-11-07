using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMiniButton : MonoBehaviour
{
    public GameObject Sipka;
    public float RotationSpeed;
    public float Distance;


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
        ispressed = true;
    }

    public void OnPointerUp()
    {
        ispressed = false;
    }



    public void Doleva()
    {
        Debug.LogWarning("Doleve");
        Sipka.transform.Rotate(0, 0, (Distance * RotationSpeed * Time.deltaTime), Space.World);
    }
}
