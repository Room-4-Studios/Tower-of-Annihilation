using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    public float currentHealth;
    public float maxHealth;
    PlayerManager Player;

    void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        currentHealth = Player.currentHealth;
        HealthBar.fillAmount = currentHealth / Player.maxHealth;
    }
}
