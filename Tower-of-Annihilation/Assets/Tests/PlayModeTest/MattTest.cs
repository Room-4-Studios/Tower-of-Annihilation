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
        public GameObject Slime;
        public GameObject Player;
        Vector3 location;
        
        GameObject clone_slime;
        
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Demo Scene");
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
            Slime=GameObject.Find("Slime");
            Player=GameObject.Find("Player");
            

            Player.GetComponent<PlayerManager>().currentHealth=100000;
            
            while(Slime.transform.position!=location)
            {
               yield return new WaitForSeconds(2f);
               
                
               allSlime++;

               clone_slime = GameObject.Instantiate(Slime, new Vector2(4f,0f), Quaternion.identity) as GameObject;
               Debug.Log($"Total number of slimes in scene: {allSlime}");
               location= Slime.transform.position;
            }

            Assert.AreEqual(allSlime, 1000, "Test failed after " + allSlime + " slimes were spawned.");
           
            yield return null;
        }

       
    }
}

