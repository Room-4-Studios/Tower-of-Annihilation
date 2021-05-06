using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Tests
{
    public class ScottTestSuite
    {
        private GameObject Enemy;
        private GameObject Chest;
        private float position;
        private float newPosition;
        
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Introduction Level");
        }

        [UnityTest]
        public IEnumerator DidSceneLoad()
        {
            Assert.AreEqual(SceneManager.sceneCount, 1);
            yield return null;
        }

        /*Unit Test*/
        [UnityTest]
        public IEnumerator DoesEnemyMoveAtStart()
        {
            Enemy = GameObject.Find("Slime(Clone)");
            position = Enemy.GetComponent<Transform>().position.x;
            yield return new WaitForSeconds(.1f);
            Assert.AreNotEqual(position, Enemy.GetComponent<Transform>().position.x);
            Assert.Pass("The Enemy started moving when the scene was loaded.");
        }

        /*Integration Test*/
        [UnityTest]
        public IEnumerator IsEnemyStuck()
        {
            Enemy = GameObject.Find("Slime(Clone)");
            int i = 0;
            for(i = 0; i < 10; i++)
            {
                position = Enemy.GetComponent<Transform>().position.x;
                yield return new WaitForSeconds(1.0f);
                newPosition = Enemy.GetComponent<Transform>().position.x;
                Assert.AreNotEqual(position.ToString("#.0"), newPosition.ToString("#.0"), "Enemy stopped moving");
            }
            Assert.Pass("After " + i + " seconds the enemy did not get stuck.");
        }

        /*Stress Test*/
        [UnityTest]
        public IEnumerator ChangeLevelsStress()
        {
            int i = 0;
            int count = 0;
            int initializedScenes = 0;
            float time = 0.2f;
            for(i = 0; i < 30; i++)
            {
                SceneManager.LoadScene("Introduction Level");
                if (time > 0.0000001)
                {
                    yield return new WaitForSecondsRealtime(time);
                }
                count++;
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
                {
                    initializedScenes++;
                }
                SceneManager.LoadScene("Level 1");
                if (time > 0.0000001)
                {
                    yield return new WaitForSecondsRealtime(time);
                }
                 count++;
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Introduction Level"))
                {
                    initializedScenes++;
                }
                SceneManager.LoadScene("Level 2");
                if (time > 0.0000001)
                {
                    yield return new WaitForSecondsRealtime(time);
                }
                count++;
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
                {
                    initializedScenes++;
                }
                time /= 2;
                if (initializedScenes != count)
                {
                    Assert.AreEqual(count, initializedScenes, "Test Failed after scene changed " + initializedScenes);
                }
            }
            Assert.AreEqual(count, initializedScenes);
            /* Test fails around a count of 800 */
            yield return null;
        }

    }
}
