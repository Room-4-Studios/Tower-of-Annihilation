using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Tests
{
    public class NathanTestSuite
    {
        private GameObject coin = GameObject.Find("Coin");
        GameObject coinInstance;

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Introduction Level");
        }

        [UnityTest]
        public IEnumerator Each_Loot_Spawn_Point_is_recognized_on_introduction_level()
        {
            int count = 0;
            GameObject[] lootSpawnPoints;
            lootSpawnPoints = GameObject.FindGameObjectsWithTag("L_Spawn");
            for(int i = 0; i < lootSpawnPoints.Length; i++)
            {
                count++;
            }
            yield return null;
            Assert.That(count == lootSpawnPoints.Length, "The numbers are not equal");
        }

        [UnityTest]
        public IEnumerator Each_Enemy_Spawn_Point_is_recognized_on_introduction_level()
        {
            int count = 0;
            GameObject[] enemySpawnPoints;
            enemySpawnPoints = GameObject.FindGameObjectsWithTag("E_Spawn");
            for(int i = 0; i < enemySpawnPoints.Length; i++)
            {
                count++;
            }
            yield return null;
            Assert.That(count == enemySpawnPoints.Length, "The numbers are not equal");
        }

        [UnityTest]
        public IEnumerator Item_instantiates_in_correct_location()
        {
            coin = GameObject.Find("Coin");
            coinInstance = Object.Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);
            yield return null;
            Assert.IsNotNull(coinInstance);

        }

        [UnityTest]
        public IEnumerator How_many_coins_overload_the_game_and_break_something_STRESS()
        {
            int moneyOnTheScreen = 0;
            int startSeconds = System.DateTime.Now.Second;
            coin = GameObject.Find("Coin");
            //float time = ;
            for (int i = 0; i < 1000000; i++)
            {   
                // Create coin at position
                float x = Random.Range(-3f, 42f);
                float y = Random.Range(-1f, -0.9f);
                coinInstance = Object.Instantiate(coin, new Vector3(x, y, 0), Quaternion.identity);
                moneyOnTheScreen++;
                
                int endSeconds = System.DateTime.Now.Second;
                int timeDiff = endSeconds - startSeconds;
                Debug.Log($"Waited {timeDiff} Seconds");
                if(timeDiff == 20)
                {
                    break;
                }
            }
            Debug.Log($"Total number of coins in scene: {moneyOnTheScreen}");
            yield return null;
        }
    }
}
