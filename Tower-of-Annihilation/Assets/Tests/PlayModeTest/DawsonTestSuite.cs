using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Tests
{
    public class DawsonTestSuite
    {
        private GameObject player = GameObject.Find("Player");
        GameObject playerInstance;

        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Introduction Level");
        }

        [UnityTest]
        public IEnumerator How_many_player_prefabs_break_the_game()
        {
            int everyoneIsHere = 0;
            int startSeconds = System.DateTime.Now.Second;
            player = GameObject.Find("Player");
            for (int i = 0; i < 1000000; i++)
            {
                float x = UnityEngine.Random.Range(-3f, 42f);
                float y = UnityEngine.Random.Range(-1f, -0.9f);
                playerInstance = UnityEngine.Object.Instantiate(player, new Vector3(x, y, 0), Quaternion.identity);
                everyoneIsHere++;
                
                int endSeconds = System.DateTime.Now.Second;
                int timeDiff = endSeconds - startSeconds;
                Debug.Log($"Waited {timeDiff} Seconds");
                if(timeDiff == 20)
                {
                    break;
                }
            }
            Debug.Log($"Total number of players scene: {everyoneIsHere}");
            yield return null;
        }
    }
}
