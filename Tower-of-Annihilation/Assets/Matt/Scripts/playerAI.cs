using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.IO;


public class playerAI : MonoBehaviour
{
     IAstarAI ai;
     public float radius;
     public Rigidbody2D rb2d;
     public float attackRange;
     private float previousMovement;
     public GameObject player;
     public Vector2 movement;
     GameObject[] enemy;
     GameObject nextLevel;
    public Transform attackPoint;
    public Transform attackPointLeft;
    public Transform attackPointTop;
    public Transform attackPointBottom;
    public LayerMask enemylair;
    public int attackDamage;
    void Start()
    {
      ai = GetComponent<IAstarAI>();
      rb2d = GetComponent<Rigidbody2D>();
      enemy = GameObject.FindGameObjectsWithTag("Enemy");
      nextLevel = GameObject.FindGameObjectWithTag("NL");
    }
    void Update()
    {
         if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) 
        {
            if(enemy!=null)
            {
             for(int i=0; i < enemy.Length; i++)
             {
                if(enemy[i]!=null)
                {
                  ai.destination = enemy[i].transform.position;
                }
             }
             
            }
            else
            {
                ai.destination=nextLevel.transform.position;
            } 
            ai.SearchPath();
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
        }
        movement.x=ai.steeringTarget.x;
        movement.y=ai.steeringTarget.y;
        GetComponent<PlayerManager>().animator.SetFloat("Horizontal", movement.x);
        GetComponent<PlayerManager>().animator.SetFloat("Vertical", movement.y);
        GetComponent<PlayerManager>().animator.SetFloat("Speed", ai.velocity.sqrMagnitude);
        

        if(movement.x >= 0 || movement.x <= 0)
        {
            // Animator setting, checking if the player is moving left or right
            GetComponent<PlayerManager>().animator.SetFloat("LastMoveX", movement.x);
            previousMovement = movement.x;
        }
        
        AttackEnemy();

    }

    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * radius;
        point.y = Random.Range(-5,5);
        // point.y = 0; // Added a range value for vertical movement.
        point += ai.position;
        return point;
    }
    void AttackEnemy()
    {
        
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylair);
            foreach(Collider2D enemy in hitEnemies)
            {
                GetComponent<PlayerManager>().animator.SetTrigger("Attack");
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            }
        
            Collider2D[] hitEnemiesl = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemylair);
            foreach(Collider2D enemy in hitEnemiesl)
            {
                GetComponent<PlayerManager>().animator.SetTrigger("Attack");
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                
            }
            Collider2D[] hitEnemiest = Physics2D.OverlapCircleAll(attackPointTop.position, attackRange, enemylair);
            foreach(Collider2D enemy in hitEnemiest)
            {
                GetComponent<PlayerManager>().animator.SetTrigger("Attack");
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            }
            Collider2D[] hitEnemiesb = Physics2D.OverlapCircleAll(attackPointBottom.position, attackRange, enemylair);
            foreach(Collider2D enemy in hitEnemiesb)
            {
                GetComponent<PlayerManager>().animator.SetTrigger("Attack");
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            }
        
    }
    
}
