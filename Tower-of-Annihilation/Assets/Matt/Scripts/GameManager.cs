﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI coin;
    GameObject Player;
    private IEnumerator dead()
    {
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        Player= GameObject.FindGameObjectWithTag("Player");
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      gameover();
    }

    void gameover()
    {
        if(Player.GetComponent<PlayerManager>().dead == true)
        {
           gameOverText.gameObject.SetActive(true);
           StartCoroutine(dead());
        }
    }
}
