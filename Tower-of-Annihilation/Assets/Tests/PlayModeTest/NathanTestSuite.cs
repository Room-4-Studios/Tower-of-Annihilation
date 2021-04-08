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
        private GameObject coin = GameObject.Find("Coin");
        GameObject coinInstance;

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Level 1");
        }

        [UnityTest]
        public IEnumerator How_many_coins_overload_the_game_and_break_something()
        {
            int moneyOnTheScreen = 0;
            int startSeconds = System.DateTime.Now.Second;
            coin = GameObject.Find("Coin");
            //float time = ;
            for (int i = 0; i < 1000000; i++)
            {
                // Start Timer
                // Make Coin
                // if time > expected time for spawn break;
                
                // Create coin at position
                float x = Random.Range(-3f, 42f);
                float y = Random.Range(-1f, -0.9f);
                coinInstance = Object.Instantiate(coin, new Vector3(x, y, 0), Quaternion.identity);
                moneyOnTheScreen++;
                
                int endSeconds = System.DateTime.Now.Second;
                int timeDiff = endSeconds - startSeconds;
                Debug.Log($"Waited {timeDiff} Seconds");
                if(timeDiff == 10)
                {
                    break;
                }
                // Debug.Log($"Start seconds: {startSeconds}");
                // Debug.Log($"End seconds: {endSeconds}");
            }
            Debug.Log($"Total number of coins in scene: {moneyOnTheScreen}");
            //Assert.AreEqual(moneyOnTheScreen, 9999, "Test Failed after " + moneyOnTheScreen + " coins on screen.");
            yield return null;
        }
    }
}
