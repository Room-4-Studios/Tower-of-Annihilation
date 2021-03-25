using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class NathanTestSuite
    {
        private GameObject coin;
        GameObject clone_coin;

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Demo Scene");
        }

        [UnityTest]
        public IEnumerator How_many_coins_overload_the_game_and_break_something()
        {
            int moneyOnTheScreen = 0;


            coin = GameObject.Find("Coin");
            for (int i = 0; i < 10000; i++)
            {
                float x = Random.Range(-3f, 42f);
                float y = Random.Range(-1f, -0.9f);
                clone_coin = GameObject.Instantiate(coin, new Vector2(23.74f,1.14f), Quaternion.identity) as GameObject;
                moneyOnTheScreen++; 
            }
            Debug.Log($"Total number of coins in scene: {moneyOnTheScreen}");
            Assert.AreNotEqual(moneyOnTheScreen, 9999, "Test Failed after " + moneyOnTheScreen + " coins on screen.");
            yield return null;
        }
    }
}
