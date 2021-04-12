using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile projectile;
    
    // rate of fire
    public float msBetweenShot = 100;
    // how fast the projectile will leave the gun
    public float muzzleVelocity = 35;

    private float nextShotTime;
    
    public void Shoot()
    {
        // Makes sure we don't fire every second and sticks to the fire rate mentioned in msBetweenShot variable
        if (Time.time > nextShotTime)
        {
            // After firing it sets the time when we should be able to fire again
            nextShotTime = Time.time + msBetweenShot / 1000;
            
            // Everytime we "Shoot" it spawns a projectile object at the muzzle's position and with its rotation
            Projectile newProjectile = 
                Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            
            // Sets how fast the projectile will be
            newProjectile.SetSpeed(muzzleVelocity);
        }
        
    }
}
