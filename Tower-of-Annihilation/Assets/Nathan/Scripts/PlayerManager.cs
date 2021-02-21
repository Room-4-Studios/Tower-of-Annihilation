using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public Transform player;
    public Rigidbody2D rb;
    public int maxHealth;
    private int currentHealth;
    public int money;
    //public float thrust; ?? for Knockback later - Nathan


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

    public void Money()
    {
        money++;
        Debug.Log("Coin!");
    }
}
