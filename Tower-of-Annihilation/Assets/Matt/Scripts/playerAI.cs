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
     Transform enemy;
    public Transform attackPoint;
    public Transform attackPointLeft;
    public LayerMask enemyLayer;
    private float nextAttackTime = 0f;
    public float attackRate;
    public int attackDamage;
    void Start()
    {
      ai = GetComponent<IAstarAI>();
      rb2d = GetComponent<Rigidbody2D>();
      enemy = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
         if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) 
        {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
        movement.x=player.transform.position.x;
        movement.y=player.transform.position.y;
        GetComponent<PlayerManager>().animator.SetFloat("Horizontal", movement.x);
        GetComponent<PlayerManager>().animator.SetFloat("Vertical", movement.y);
        if(ai.velocity.x>0)
        {
            GetComponent<PlayerManager>().animator.SetFloat("Speed", ai.velocity.x);
        }
        else
        {
            GetComponent<PlayerManager>().animator.SetFloat("Speed", ai.velocity.y);
        }
        if(Input.GetAxis("Horizontal") >= 1 || Input.GetAxis("Horizontal") >= -1)
        {
            // Animator setting, checking if the player is moving left or right
            GetComponent<PlayerManager>().animator.SetFloat("LastMoveX", Input.GetAxis("Horizontal"));
            previousMovement = Input.GetAxis("Horizontal");
        }

        float distanceToEnemy = Vector2.Distance(transform.position, enemy.position);
        
        if(distanceToEnemy < attackRange)
        {
            Debug.Log("Attacking");
            AttackEnemy();
        }
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
        //Debug.Log(GetComponent<PlayerMovement>().GetPreviousMovement());
        GetComponent<PlayerManager>().animator.SetTrigger("Attack");
        if(previousMovement >= 1)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                Debug.Log("We hit " + enemy.name);
            }
        }
        else if(previousMovement <= -1)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                Debug.Log("We hit " + enemy.name);
            }
        }
    }
}
