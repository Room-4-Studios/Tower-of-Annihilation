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
            int i = 0;
            int allSlime= 8;
            Slime=GameObject.Find("Slime");
            for(i = 0; i < 800000; i++)
            {
               
               float x = Random.Range(-3.4f, 41.69f);
               float y = Random.Range(-1.45f, -.94f);

               allSlime++;

               clone_slime = GameObject.Instantiate(Slime, new Vector2(x,y), Quaternion.identity) as GameObject;
               Debug.Log($"Total number of slimes in scene: {allSlime}");
 
            }
            Assert.AreNotEqual(allSlime, 800008, "Test Failed after " + allSlime + " slimes spawned");
           
            yield return null;
        }
    }
}

