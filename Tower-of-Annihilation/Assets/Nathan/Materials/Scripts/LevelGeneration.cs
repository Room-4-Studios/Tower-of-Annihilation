using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    GameObject[] enemySpawnPoints;
    GameObject[] lootSpawnPoints;
    [SerializeField] public GameObject[] enemies;
    [SerializeField] public GameObject[] loots;
    
    void Start()
    {
        enemySpawnPoints = GameObject.FindGameObjectsWithTag("E_Spawn");
        lootSpawnPoints = GameObject.FindGameObjectsWithTag("L_Spawn");
        SpawnEnemies();
        SpawnLoot();
    }

    void SpawnEnemies()
    {        
        // For each spawn point, select an enemy from enemies, and instantiate it at its spawnpoint
        for(int i = 0; i < enemySpawnPoints.Length; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], enemySpawnPoints[i].transform.position, Quaternion.identity);
        }
    }

    void SpawnLoot()
    {
        // For each loot spawn point, select a piece of loot, and instantiate it at its spawnpoint
        for(int i = 0; i < lootSpawnPoints.Length; i++)
        {
            Instantiate(loots[Random.Range(0, loots.Length)], lootSpawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
