using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyzmo : MonoBehaviour {



    private void OnDrawGizmos()//
    {
        Gizmos.color = Color.blue;        
              
        Gizmos.DrawSphere(transform.position + transform.forward * 45f, 45f);
    }
}
