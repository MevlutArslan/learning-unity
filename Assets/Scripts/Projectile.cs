using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Which layer of objects it will collide with
    public LayerMask collisionMask;
    private float _speed = 10;

    private float damage = 2;
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    private void Update()
    {
        float moveDistance = _speed * Time.deltaTime;

        CheckCollision(moveDistance);
        
        // Moves the object _speed times forward every deltaTime
        transform.Translate( Vector3.forward * moveDistance);
        
    }

    void CheckCollision(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
    
        // If the ray shot from the projectiles location going forward hits
        // anything in the collisionMask layer 
        if (Physics.Raycast(ray, out hit, moveDistance, 
            collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();

        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage, hit);
        }
        
        GameObject.Destroy(gameObject);
    }
}
