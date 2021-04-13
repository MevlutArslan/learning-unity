using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Will force it to attach these to the player!
[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : Entity
{
    public float moveSpeed = 5;

    Camera viewCamera;
    public PlayerController controller;

    GunController _gunController;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
        _gunController = GetComponent<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(horizontalInput, 0, verticalInput);

        Vector3 moveVelocity = moveInput.normalized * moveSpeed;

        controller.Move(moveVelocity);
        
        // Camera/Look Input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayDistance;

        // the out keyword assigns the value to the same variable
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);

            controller.LookAt(point);
        }
        
        // Weapon Input
        if (Input.GetMouseButton(0))
        {
            _gunController.Shoot();
        }
        
    }
}
