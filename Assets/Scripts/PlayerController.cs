using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Forcing the engine to bring in a RigidBody
[RequireComponent ( typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 velocity;

    // Physics stuff
    Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // Initializing the Rigidbody
        myRigidBody = GetComponent<Rigidbody>();    
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // Executed at small regular steps
    private void FixedUpdate()
    {
        // Adds the velocity multiplied by the fixedinterval the FixedDeltaTime runs in
        // to the current position 
        myRigidBody.MovePosition(
            myRigidBody.position + velocity * Time.fixedDeltaTime
        );
        
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightAdjustedLookPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightAdjustedLookPoint);
    }
}
