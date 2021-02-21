using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ShopInterface
{
    public float moveSpeed;
    public Animator animator;
    public Transform player;
    public Rigidbody2D rb;
    public int maxHealth;
    private int currentHealth;
    public int money;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Camera.main.GetComponent<FollowCamera>().player=transform; /*  Follow Camera properly placed on spawning character -Matt */
    }

    public void TakeDamage(int Damage)
    {
        animator.SetTrigger("Hurt");
        Debug.Log("Taking Damage");
        currentHealth -= Damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
    }

    //Regarding purchasing items.
    public int CurrentMoney()
    {
        return money;
    }

    public void BoughtItem(string name, int cost)
    {
        Debug.Log("Bought: " + name + " with " + cost + " gold.");
    }

    public bool AttemptBuy(int cost)
    {
        if (CurrentMoney() >= cost) 
        {
            money -= cost;
            return true;
        }
        else
        {
            return false;
        }

    }
}
