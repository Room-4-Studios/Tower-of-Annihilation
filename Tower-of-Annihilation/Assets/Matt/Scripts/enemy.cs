using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class enemy : MonoBehaviour
{
    public static enemy isBusy;
    public Transform attackPoint;
    public Transform player;
    public Transform castPoint;
    Quaternion q;
    public float radius;
    public float aggroRange;
    public float moveSpeed;
    public Rigidbody2D rb2d;
    Vector3 direction;
    IAstarAI ai;

    public float attackRange;
    public int enemyDamage;
    
    public Animator animator;
    public LayerMask playerLayer;

    public int maxHealth;
    private int currentHealth;

    float timerForNextAttack;
    public float cooldown;

    // These do not need declared with values. setup per 
    // public float radius = 50;
    // public float agroRange = 30;
    // public float moveSpeed = 7;
    
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        rb2d = GetComponent<Rigidbody2D>();
        direction = transform.up;
        Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
        direction = q * direction;

        currentHealth = maxHealth;
        timerForNextAttack = cooldown;
    }

    void Update()
    {
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) 
        {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
        LookForPlayer();


        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer < attackRange)
        {
            //Debug.Log("Player is in range");
            if(timerForNextAttack > 0)
            {
                timerForNextAttack -= Time.deltaTime;
            }
            else if(timerForNextAttack <= 0)
            {
                animator.SetTrigger("Attack");
                Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
                Debug.Log("Attacking Player.");

                foreach(Collider2D player in hitPlayers)
                {
                    player.GetComponent<PlayerManager>().TakeDamage(enemyDamage);
                }
                timerForNextAttack = cooldown;

            }
        }

    }

    public bool canSeePlayer(float distance)
    {
        bool seePlayer = false;
        
        Vector2 endPos = castPoint.position + direction * distance;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));
       
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                //Lets Aggro the Enemy
                seePlayer = true;          
            }
            else
            {
                Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
                direction = q * direction;
                seePlayer = false;
            }
        }
        else
        {
            Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
            direction = q * direction;
        }
        //For raycast to work! set player(Tag:Player , Layer:Action) enemy(s)(Tag:Enemy, Layer:Default)
        return seePlayer;
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
    
    public bool StopChasingPlayer()
    {
        if (canSeePlayer(aggroRange) == false)
        {
            return true;
        }
        return false;
    }

    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * radius;
        point.y = Random.Range(-5,5);
        // point.y = 0; // Added a range value for vertical movement.
        point += ai.position;
        return point;
    }

    void LookForPlayer()
    {
        if(canSeePlayer(aggroRange))
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        animator.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<AIPath>().enabled = false;
        this.enabled = false;
        Destroy(this);
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

