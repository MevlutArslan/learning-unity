using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    protected float health;
    public bool isDead;
    
    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        health -= damage;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    protected void Die()
    {
        isDead = true;
        
        // No idea how this works.
        if (OnDeath != null)
        {
            OnDeath();
        }
        
        GameObject.Destroy(gameObject);
    }
}
