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
        }

        [UnityTest]
        public IEnumerator DidSceneLoad()
        {
            Assert.AreEqual(SceneManager.sceneCount, 1);
            yield return null;
        }

        [UnityTest]
        public static void ClickButton()
        {
        // Find button Game Object
        string name = "PlayButton";
        var go = GameObject.Find(name);
        Assert.IsNotNull(go, "Missing button " + name);
        // Invoke click
        go.GetComponent<Button>().onClick.Invoke();
        }
    }
}
