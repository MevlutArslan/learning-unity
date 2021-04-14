using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    // What type of enemy to spawn
    public Enemy enemy;
    
    private int enemiesRemainingToSpawn;
    private float nextSpawnTime;

    private int enemiesRemainingAlive;

    private Wave currentWave;
    private int currentWaveNumber;

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        // I dont know what Time.time > nextSpawnTime does 🤨
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            // Informs the system when to spawn the next enemy according to the currentWave's properties
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
            
            // Spawns enemy at 0,0,0 with default rotation
            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            // if the OnDeath event on Enemy is triggered then runs the OnEnemyDeath function ?? Not sure 🧐
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }
    
    // Handles the switch to the Next Wave
    void NextWave()
    {
        currentWaveNumber ++;

        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
    }
    
    // Keeps track of enemies remaining and switches to the nextWave as necessary
    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;
        
        if (enemiesRemainingAlive == 0) 
        {
            NextWave();
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
    
    
}
