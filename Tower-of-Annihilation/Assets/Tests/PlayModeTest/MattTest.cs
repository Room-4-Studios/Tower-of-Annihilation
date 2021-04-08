using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

using UnityEngine.TestTools;

using UnityEngine.SceneManagement;

namespace Tests
{
    public class MattTest
    {
        private GameObject[] Slime;
        private GameObject Player;
        Vector3 movement;
        
        GameObject clone_slime;
        
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Level 1");
        }

        [UnityTest]
        public IEnumerator DidSceneLoad()
        {
            Assert.AreEqual(SceneManager.sceneCount, 1);
            yield return null;
        }

 

        [UnityTest]
        public IEnumerator Stampede()
        {
            
            int allSlime= 0;
            Slime=GameObject.FindGameObjectsWithTag("Enemy");
            Player=GameObject.Find("Player");
            

            Player.GetComponent<PlayerManager>().currentHealth=100000;
            
            
        
            movement = new Vector3 (0,0,0);
                
                while(movement!=Slime[0].transform.position)
                {
                    movement=Slime[0].transform.position;
                    yield return new WaitForSeconds(.5f);
                    clone_slime = GameObject.Instantiate(Slime[0], new Vector2(2,-2), Quaternion.identity) as GameObject;
                    allSlime++;   
                    Debug.Log($"Total number of slimes in scene: {allSlime}");
                }
                
               
            
            Debug.Log($"Total number of slimes in scene: {allSlime}");
            Assert.AreEqual(49, allSlime, "A* was no longer efficiently compute when " + allSlime + " Slimes were spawned.");
           
            yield return null;
            /* This test stresses the A* Pathfinding system for the Enemy AI feature. Essentially, 
             * the pathfinder dictates movement for the enemy AI if too many agents are spawned the pathfinding
             * algorithm cannot process movement, thus, the slimes cease movement and the while loop exits completing 
             * the stress test and returning count of enemies spawned */
        }

       
    }
}

