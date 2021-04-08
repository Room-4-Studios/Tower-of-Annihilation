using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;


namespace Tests
{
    public class KimTestSuite
    {
        private GameObject shopkeeper;
        private GameObject canvas;
        private GameObject coin;
        GameObject clone_shop;
        GameObject clone_canvas;
        GameObject clone_coin;

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Demo Scene");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.

        //See if coin moves from stack.
        /*[UnityTest]
        public IEnumerator CoinPositionStress()
        {
            int i = 0;
            int totalShop = 1;
            shopkeeper = GameObject.Find("Shopkeeper");
            canvas = GameObject.Find("Canvas");
            coin = GameObject.Find("Coin");
            //float x;
            //float y;
            for (i = 0; i < 100; i++)
            {
                //yield return new WaitForSeconds(0.0001f);
                //x = Random.Range(-3f, -2.9f);
                //y = Random.Range(-1f, -0.9f);
                clone_shop = GameObject.Instantiate(shopkeeper, shopkeeper.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
                clone_canvas = GameObject.Instantiate(canvas, canvas.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
                if (coin != null)
                {
                    clone_coin = GameObject.Instantiate(coin, new Vector2(-3, 1), Quaternion.identity) as GameObject;
                    totalShop++;
                }
                if(coin.transform.position.x  < -3.45f || coin.transform.position.x > -2.55f)
                {
                    Assert.AreEqual(1010, totalShop, "Coin moved after " + totalShop + " coins were added to the scene.");
                }
                totalShop++;
                Debug.Log($"Total number of shopkeepers in scene: {totalShop}");
            }
            Assert.AreEqual(100, totalShop, "Coin moved after " + totalShop + " coins were added to the scene.");

            yield return null;
        }*/

        [UnityTest]
        public IEnumerator HowManyShopkeepersBreakGame()
        {
            int i = 0;
            int totalShop = 1;
            shopkeeper = GameObject.Find("Shopkeeper");
            canvas = GameObject.Find("Canvas");
            coin = GameObject.Find("Coin");
            float x;
            float y;
            for (i = 0; i < 2000; i++)
            {
                //yield return new WaitForSeconds(0.0001f);
                x = Random.Range(-3f, -2.9f);
                y = Random.Range(-1f, -0.9f);
                clone_shop = GameObject.Instantiate(shopkeeper, shopkeeper.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
                clone_canvas = GameObject.Instantiate(canvas, canvas.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
                if (coin != null)
                {
                    clone_coin = GameObject.Instantiate(coin, new Vector2(x, y), Quaternion.identity) as GameObject;
                }
                totalShop++;
                Debug.Log($"Total number of shopkeepers in scene: {totalShop}");
            }
            Assert.AreNotEqual(2000, totalShop, "Number of shopkeepers that break Unity: " + totalShop);

            yield return null;
        }
    }
}
