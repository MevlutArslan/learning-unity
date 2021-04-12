using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 10;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    private void Update()
    {
        // Moves the object _speed times forward every deltaTime
        transform.Translate( Vector3.forward * (Time.deltaTime * _speed));
    }
}
