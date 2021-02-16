﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float Health;
    public float attackRange;
    public int attackDamage;
    public Animator animator; //Get player's animations.
    public Transform attackPoint;
    public Transform attackPointLeft;
    public LayerMask enemyLayer;
    private Rigidbody2D rb;
    private float nextAttackTime = 0f;
    public float attackRate;

    // Does not need values. set in unity.
    // public float attackRange = 0.5f;
    // public int attackDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Get the players Rigidbody2D 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown("space"))
            {
                AttackEnemy();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void AttackEnemy() 
    { 
        //Debug.Log(GetComponent<PlayerMovement>().GetPreviousMovement());
        animator.SetTrigger("Attack");
        if(GetComponent<PlayerMovement>().GetPreviousMovement() == 1)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                Debug.Log("We hit " + enemy.name);
            }
        }
        else if(GetComponent<PlayerMovement>().GetPreviousMovement() == -1)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                Debug.Log("We hit " + enemy.name);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Enemy")
        {
            //ScriptNameHere nom = collision.GetComponent<ScriptNameHere>();

            //Health -= nom.damage;

            //Destroy(nom.gameObject);
        }
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null || attackPointLeft == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
    }
}