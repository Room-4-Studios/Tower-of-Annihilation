using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class KimTestSuite
    {
        private GameObject shopkeeper;
        private GameObject canvas;
        GameObject clone_shop;
        GameObject clone_canvas;

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Demo Scene");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.

        // I don't know if this works well enough.
        [UnityTest]
        public IEnumerator HowManyShopKeepersBreakGameStress()
        {
            int i = 0;
            int totalShop = 1;
            shopkeeper = GameObject.Find("Shopkeeper");
            canvas = GameObject.Find("Canvas");
            for (i = 0; i < 1000; i++)
            {
                yield return new WaitForSeconds(0.1f);
                clone_shop = GameObject.Instantiate(shopkeeper, shopkeeper.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
                clone_canvas = GameObject.Instantiate(canvas, canvas.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
                totalShop++;
                Debug.Log($"Total number of shopkeepers in scene: {totalShop}");
            }
            Assert.AreNotEqual(totalShop, 1001, "Test failed after " + totalShop + " shopkeepers were spawned.");
            //Fails at 950 or less.
            yield return null;
        }
    }
}
