using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    GameObject[] badBois;
    public GameObject Slime;
    public GameObject Plunder;
    public GameObject Dubloon;
    GameObject[] Shinies;
    

    void Start()
    {
        
        badBois = GameObject.FindGameObjectsWithTag("E_Spawn");
        Shinies = GameObject.FindGameObjectsWithTag("L_Spawn");
        
        spawnEnemies();
        spawnBooty();
       
        //int rand = Random.Range(0, objects.Length);
        //Instantiate(objects[rand], transform.position, Quaternion.identity);
    }

    void spawnEnemies()
    {
       int rand = Random.Range(0, badBois.Length);
       
       for(int i=0; i<rand;i++)
       {
           Instantiate(Slime,badBois[i].transform.position,Quaternion.identity);
       }

    }

    void spawnBooty()
    {
       int rand = Random.Range(0, Shinies.Length);
       
       for(int i=0; i<rand;i++)
       {
           int roll = Random.Range(0,2);

           switch(roll)
           {
               case 0:
               Instantiate(Plunder,Shinies[i].transform.position,Quaternion.identity);
               break;

               case 1:
               Instantiate(Dubloon,Shinies[i].transform.position,Quaternion.identity);
               break;

               default:
               break;
           }
       }
    }

    
}
