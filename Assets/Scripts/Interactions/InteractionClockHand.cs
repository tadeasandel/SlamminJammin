using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionClockHand : MonoBehaviour, IInteractableObject
{
    public float RotationSpeed = 55;
    public bool isActive;
    public CameraRotation rotace;
    public float minimalRotation;
    public float maximalRotation;
    void start()
    {
      
    }
    public void Interact()
    {
        isActive = !isActive;
        //GameObject.Find("Player").GetComponent<CameraRotation>().pauza = isActive;
        rotace.pauza = isActive;

    }

    public bool IsUsed()
    {
        return false;
       
    }

      // Update is called once per frame
    void Update()
    {
        if (isActive )
        {
            this.transform.Rotate(0, 0, (Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), Space.World);
            //Debug.Log(this.transform.localRotation.z);
        }
        if (isActive && Input.GetMouseButtonUp(0))
        {
            isActive = false;
            rotace.pauza = isActive;
        }
        if (this.transform.localRotation.z < minimalRotation && this.transform.localRotation.z > maximalRotation)
        {
            Debug.Log("jop");
        }
      


    }


}
