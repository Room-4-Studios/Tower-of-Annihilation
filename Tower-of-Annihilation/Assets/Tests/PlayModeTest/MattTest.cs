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
        public IEnumerator Nickelodeon()
        {
            
            int allSlime= 8;
            Slime=GameObject.Find("Slime");
            Player=GameObject.Find("Player");

            while(Player.transform.position.x>21.66f&&Player.transform.position.y<4.81f)
            {
               yield return new WaitForSeconds(0.1f);
               //float x = Random.Range(-3.4f, 41.69f);
               //float y = Random.Range(-1.45f, -.94f);

               allSlime++;

               clone_slime = GameObject.Instantiate(Slime, new Vector2(23.74f,1.14f), Quaternion.identity) as GameObject;
               Debug.Log($"Total number of slimes in scene: {allSlime}");
 
            }

            Assert.AreNotEqual(allSlime, 8, "Test failed after " + allSlime + " slimes were spawned.");
           
            yield return null;
        }
    }
}

