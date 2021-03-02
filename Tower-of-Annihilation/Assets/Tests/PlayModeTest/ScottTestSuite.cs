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
        private GameObject testObject;
        private Vector3 position, newPosition;
        
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            SceneManager.LoadScene("Demo Scene");
            position = GameObject.Find("Player").GetComponent<Rigidbody>().transform.position;
            yield return new WaitForSeconds(.1f);
            newPosition = GameObject.Find("Player").GetComponent<Rigidbody>().transform.position;
            if (position == newPosition)
            {
                Assert.Fail();
            }

            
            //Assert.IsNotNull(GameObject.Instantiate(Resources.Load<GameObject>("Main Camera")));
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
        /*
        [UnityTest]
        public IEnumerator EnemyMovesOnStart()
        {
            setupScene();
            GameObject.Instantiate(Resources.Load<GameObject>("Player"));
            
            for(int i = 0; i < 10; i++)
            {
                position = GameObject.Find("Player").GetComponent<Rigidbody>().transform.position;
                yield return new WaitForSeconds(.1f);
                newPosition = GameObject.Find("Player").GetComponent<Rigidbody>().transform.position;
                if(position == newPosition)
                {
                    Assert.Fail();
                }

            }

            Assert.AreNotEqual(newPosition, position, "EnemyMovesOnStart: Test Passed. " +
                "Enemy moved from " + position + "to " + newPosition + ".");
        }
        
        void setupScene()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Slime (7)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Slime (6)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Slime (5)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Slime (4)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Slime (3)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Slime (2)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Slime (1)"));
            //MonoBehaviour.Instantiate(Resources.Load<GameObject>("Slime"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Coin"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Shopkeeper"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Chest"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Coin (1)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Coin (2)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Chest (1)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Chest (2)"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        }*/
    }
}
