using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.IO;


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

    private ItemDrop getItem;

    // These do not need declared with values. setup per 
    // public float radius = 50;
    // public float agroRange = 30;
    // public float moveSpeed = 7;
    
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = transform.up;
        Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
        direction = q * direction;

        currentHealth = maxHealth;
        timerForNextAttack = cooldown;

        getItem = GetComponent<ItemDrop>();
        acceptance_test();
    }

    void Update()
    {
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) 
        {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
        LookForPlayer();


        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer < attackRange)
        {
            Debug.Log("Player is in range");
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
        getItem.DropItem();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AIPath>().enabled = false;
        this.enabled = false;
        Destroy(this);
        Destroy(gameObject, 2);
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void acceptance_test(){
     Vector3 point;

     string path ="Assets/Matt/Scripts/Test.txt";
     StreamWriter writer = new StreamWriter(path,true);

     float xavg=0;
     float yavg=0;
     float path_size=0;

     for(int i=0; i < 1000; i++){
         point=PickRandomPoint();
         xavg+=point.x;
         yavg+=point.y;
         
     }


     xavg= xavg/1000;
     yavg= yavg/1000;

     path_size=Mathf.Pow(2,xavg) + Mathf.Pow(2,yavg);
     path_size=Mathf.Sqrt(path_size);

     writer.WriteLine("X-AVG: {0}, Y-AVG {1}, Path_Size {2}",xavg,yavg,path_size); 
     writer.Close();
    }
}

