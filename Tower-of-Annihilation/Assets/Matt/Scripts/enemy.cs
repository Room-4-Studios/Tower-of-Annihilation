﻿using System.Collections;
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
    Seeker seeker;
    GameObject[] battlebuddy;

    public float attackRange;
    public int enemyDamage;
    
    public Animator animator;
    public LayerMask playerLayer;

    public int maxHealth;
    public int currentHealth;

    float timerForNextAttack;
    public float cooldown;

    private ItemDrop getItem;
    public bool dead = false;

    public EnemyHealthBar healthBar;

    /* Audio added by Scott if you have questions */
    // Added to Sound Manager - Nate
    // public AudioSource slimeDeathAud;
    // public AudioClip slimeSound;
    
  

    // These do not need declared with values. setup per 
    // public float radius = 50;
    // public float agroRange = 30;
    // public float moveSpeed = 7;
    
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        seeker= GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        battlebuddy = GameObject.FindGameObjectsWithTag("Enemy");
        direction = transform.up;
        Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
        direction = q * direction;
        //Generate a Rotating Raycast

        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth); /*Scott's code for enemy health bar.*/

        timerForNextAttack = cooldown;
        
        getItem = GetComponent<ItemDrop>();
        // acceptance_test();  *Runs Acceptance Test for Enemy Patrol Picking random points -Matt

        //slimeDeathAud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) 
        {
            ai.destination=PickRandomPoint();
            ai.SearchPath();
        }
        LookForPlayer();
        CheckDistance();
        
       
        
        if(player.position.x > transform.position.x)
        {
            animator.SetTrigger("FaceRight");
            //Debug.Log("Henlo");
        }
        else
        {
            animator.SetTrigger("FaceLeft");
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if(distanceToPlayer < attackRange)
        {
            //ai.isStopped=true;
            
            //Debug.Log("Player is in range");
            if(timerForNextAttack > 0)
            {
                timerForNextAttack -= Time.deltaTime;
            }
            else if(timerForNextAttack <= 0)
            {
                animator.SetTrigger("Attack");
                Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
                //Debug.Log("Attacking Player.");

                foreach(Collider2D player in hitPlayers)
                {
                    
                    player.GetComponent<PlayerManager>().TakeDamage(enemyDamage);
                }
                timerForNextAttack = cooldown;
                
            }
        }
        else
        {
           // ai.isStopped=false;
        }
        
       
    }

   

    public bool canSeePlayer(float distance)
    {
        bool seePlayer = false;
        
        Vector2 endPos = castPoint.position + direction * distance;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));
        //generate raycast
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                //if the raycasy collides with the player stop rotating and and flag seeplayer
                seePlayer = true;          
            }
            else
            {
                //if player is not colliding return seeplayer = false and cintinue rotating raycast
                Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
                direction = q * direction;
                seePlayer = false;
            }
        }
        else
        {
            //if nothing is colliding continue rotation
            Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
            direction = q * direction;
        }
        //For raycast to work! set player(Tag:Player , Layer:Action) enemy(s)(Tag:Enemy, Layer:Default)
        //Debug.DrawLine(castPoint.position,endPos,Color.red,radius);
        return seePlayer;
    }

    void ChasePlayer()
    {
        //move toward the player
        
        seeker.CancelCurrentPathRequest();
        ai.destination = player.position;
        ai.SearchPath();
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
        var point = Random.insideUnitCircle* radius;
        point.y = Random.Range(-.5f,.5f);
        // point.y = 0; // Added a range value for vertical movement.
        point += (Vector2)ai.position;
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
        //Debug.Log(Damage);
        //Debug.Log(currentHealth);
        currentHealth -= Damage;
        animator.SetTrigger("Hurt");
        FindObjectOfType<SoundManager>().Play("Slime Hurt");
        healthBar.SetHealth(currentHealth, maxHealth); /*Scott's code for enemy health bar.*/
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<SoundManager>().Play("Slime Death");

        //Debug.Log("Enemy Died");
        dead=true;
        animator.SetBool("isDead", true);
        getItem.DropItem();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<AIPath>().enabled = false;
        this.enabled = false;
        Destroy(this);
        Destroy(gameObject, 2);
        battlebuddy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
    void CheckDistance()
    {
      
        
        for(int i=0; i < battlebuddy.Length; i++)
        {
            if(battlebuddy[i]!=null)
            {
                float distanceToBattleBuddy=Vector2.Distance(transform.position, battlebuddy[i].transform.position);
                 
                    if(distanceToBattleBuddy < attackRange&&distanceToBattleBuddy!=0)
                    {
                        seeker.CancelCurrentPathRequest();
                        ai.destination=PickRandomPoint();
                        ai.SearchPath();
                    }
            }
               
        }
        
        battlebuddy = GameObject.FindGameObjectsWithTag("Enemy");
        
    }
    
    void acceptance_test()
    {
     Vector3 point;
     // Points to TXT file in docs and opens it
     string path ="Assets/Matt/Scripts/Test.txt";
     StreamWriter writer = new StreamWriter(path,true);

     float xavg=0;   //Keep track of average and path size
     float yavg=0;
     float path_size=0;

     for(int i=0; i < 1000; i++){
         point=PickRandomPoint();
         xavg+=point.x;
         yavg+=point.y;  //Run 1000 test 
         
     }


     xavg= xavg/1000; //Get average of of x and y coor
     yavg= yavg/1000;

     path_size=Mathf.Pow(2,xavg) + Mathf.Pow(2,yavg);
     path_size=Mathf.Sqrt(path_size); //Pythagorean theorem to find average path length

     writer.WriteLine("X-AVG: {0}, Y-AVG {1}, Path_Size {2}",xavg,yavg,path_size); //write to txt file and close 
     writer.Close();
    }
}

