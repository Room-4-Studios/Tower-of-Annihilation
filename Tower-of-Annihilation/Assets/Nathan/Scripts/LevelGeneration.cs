using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    GameObject[] enemySpawnPoints;
    GameObject[] lootSpawnPoints;
    public GameObject slime;
    public GameObject chest;
    public GameObject coin;
    
    

    void Start()
    {
        
        enemySpawnPoints = GameObject.FindGameObjectsWithTag("E_Spawn");
        lootSpawnPoints = GameObject.FindGameObjectsWithTag("L_Spawn");
        
        SpawnEnemies();
        spawnLoot();
       
        //int rand = Random.Range(0, objects.Length);
        //Instantiate(objects[rand], transform.position, Quaternion.identity);
    }

    void SpawnEnemies()
    {
       int rand = Random.Range(0, enemySpawnPoints.Length);
       
       for(int i = 0; i < rand; i++)
       {
           Instantiate(slime, enemySpawnPoints[i].transform.position, Quaternion.identity);
       }

    }

    void spawnLoot()
    {
       int rand = Random.Range(0, lootSpawnPoints.Length);
       
       for(int i = 0; i < rand; i++)
       {
           int roll = Random.Range(0,2);

           switch(roll)
           {
               case 0:
               Instantiate(chest, lootSpawnPoints[i].transform.position, Quaternion.identity);
               break;

               case 1:
               Instantiate(coin, lootSpawnPoints[i].transform.position, Quaternion.identity);
               break;

               default:
               break;
           }
       }
    }

    
}
