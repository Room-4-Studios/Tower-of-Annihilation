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
            int initializedScenes = 0;
            float time = 0.2f;
            for(i = 0; i < 30; i++)
            {
                SceneManager.LoadScene("Demo Scene");
                if (time > 0.0000001)
                {
                    yield return new WaitForSecondsRealtime(time);
                }
                count++;
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Demo Scene"))
                {
                    initializedScenes++;
                }
                SceneManager.LoadScene("Introduction Scene");
                if (time > 0.0000001)
                {
                    yield return new WaitForSecondsRealtime(time);
                }
                 count++;
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Introduction Scene"))
                {
                    initializedScenes++;
                }
                SceneManager.LoadScene("ScottScene");
                if (time > 0.0000001)
                {
                    yield return new WaitForSecondsRealtime(time);
                }
                count++;
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ScottScene"))
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
