using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Entity
{
    private NavMeshAgent pathFinder;
    
    // Player's location
    private Transform target;

    protected override void Start()
    {
        base.Start();
        
        pathFinder = GetComponent<NavMeshAgent>();
        // Finds the player and assigns its location to target Transform
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }
    
    
    // This makes sure the pathfinding runs refreshRate times, instead of every frame
    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            if (!isDead)
            {
                pathFinder.SetDestination(targetPosition);

            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
