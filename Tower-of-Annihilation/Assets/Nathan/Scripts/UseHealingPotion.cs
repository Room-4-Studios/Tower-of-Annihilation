using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHealingPotion : MonoBehaviour
{
    private GameObject player;
    public int healingAmount;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Use()
    {
        player.GetComponent<PlayerManager>().UseHealItem(healingAmount);
        FindObjectOfType<SoundManager>().Play("Drink Potion");
        Destroy(gameObject);
    }
}
