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
    }

    private void Update()
    {
        pathFinder.SetDestination(target.position);
    }
}
