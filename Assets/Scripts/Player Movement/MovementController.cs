using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool isMovementPaused; //muj pridavek
    public float movementSpeed = 10.0f;

  Rigidbody rigidBody;

  void Awake()
  {
    rigidBody = GetComponent<Rigidbody>();
    Cursor.lockState = CursorLockMode.Locked;
  }

  void Update()
  {
        if (isMovementPaused) { return; }
        float xInput = Input.GetAxis("Vertical");
    float zInput = Input.GetAxis("Horizontal");

    Vector3 xVelocity = transform.forward * movementSpeed * xInput;
    Vector3 zVelocity = transform.right * movementSpeed * zInput;

    rigidBody.velocity = xVelocity + zVelocity + new Vector3(0, rigidBody.velocity.y, 0);
  }
}
