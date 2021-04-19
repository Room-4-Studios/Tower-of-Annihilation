using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDelete : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Scene scene = SceneManager.GetActiveScene();
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == "StartMenu") 
        {
                Destroy(gameObject);
        }
    }
}
