using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathFinder;
    
    // Player's location
    private Transform target;

    private void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        // Finds the player and assigns its location to target Transform
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathFinder.SetDestination(targetPosition);
            
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
