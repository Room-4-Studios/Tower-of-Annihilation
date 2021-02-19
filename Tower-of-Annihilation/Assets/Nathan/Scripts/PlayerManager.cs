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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Camera.main.GetComponent<FollowCamera>().player=transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int Damage)
    {
        Debug.Log("Taking Damage");
        currentHealth -= Damage;
        animator.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
    }
}
