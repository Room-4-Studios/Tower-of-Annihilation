using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class ScottTestSuite
    {
        private GameObject Enemy;
        private GameObject Chest;
        private float position;
        
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
        public IEnumerator DoesEnemyMoveAtStart()
        {
            Enemy = GameObject.Find("Slime");
            position = Enemy.GetComponent<Transform>().position.x;
            yield return new WaitForSeconds(.1f);
            Assert.AreNotEqual(position, Enemy.GetComponent<Transform>().position.x);
        }

        [UnityTest]
        public IEnumerator WillEnemyGetStuckOnWall()
        {
            Enemy = GameObject.Find("Slime");
            for(int i = 0; i < 5; i++)
            {
                position = Enemy.GetComponent<Transform>().position.x;
                yield return new WaitForSeconds(3.0f);
                if(position == Enemy.GetComponent<Transform>().position.x)
                {
                    Assert.AreNotEqual(position, Enemy.GetComponent<Transform>().position.x);
                }
            }
        }

        [UnityTest]
        public IEnumerator ChangeLevelsStress()
        {
            int i = 0;
            int count = 0;
            for(i = 0; i < 300; i++)
            {
                SceneManager.LoadScene("Demo Scene");
                yield return new WaitForSeconds(0.2f);
                count++;
                SceneManager.LoadScene("Introduction Scene");
                yield return new WaitForSeconds(0.2f);
                count++;
                SceneManager.LoadScene("ScottScene");
                yield return new WaitForSeconds(0.2f);
                count++;
            }
            Assert.AreNotEqual(count, 900, "Test Failed after scene changed " + count + " times");
            /* Test fails around a count of 800 */
            yield return null;
        }
    }
}
