using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    void Start()
    {
        Destroy(GameObject.Find("Player"));
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
