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
    public class DawsonTest
    {
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("StartMenu");
            DidSceneLoad("StartMenu");
        }

        [UnityTest]
        public IEnumerator ClickPlayButton()
        {
            string name = "PlayButton";
            var go = GameObject.Find(name);
            Assert.IsNotNull(go, "Missing button " + name);
            go.GetComponent<Button>().onClick.Invoke();
            DidSceneLoad("Introduction Scene");
            yield return null;
        }

        public IEnumerator DidSceneLoad(string sceneName)
        {
            Assert.AreEqual(SceneManager.GetActiveScene(), sceneName);
            yield return null;
        }
    }
}
