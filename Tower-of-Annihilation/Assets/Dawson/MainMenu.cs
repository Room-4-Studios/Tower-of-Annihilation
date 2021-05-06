﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(60);
        PickScene();
    }

    void Start()
    {
      StartCoroutine(Wait());
    }
    public void PlayGame()
    {
        StopCoroutine(Wait());
        SceneManager.LoadScene("Introduction Level");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    void PickScene()
    {
        int scene=0;
        scene=Random.Range(0,2);

        switch (scene)
        {
            case 0:
                SceneManager.LoadScene("DemoMode_level1");
                break;
            case 1:
                SceneManager.LoadScene("DemoMode_level2");
                break;
            default:
                PickScene();
                break;
        }
    }
}
