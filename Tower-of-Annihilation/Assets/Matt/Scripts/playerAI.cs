using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.IO;
using UnityEngine.SceneManagement;


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
    GameObject[] coin;
    GameObject[] chest;
    GameObject nextLevel;
    public Transform attackPoint;
    public Transform attackPointLeft;
    public Transform attackPointTop;
    public Transform attackPointBottom;
    public LayerMask enemyLayer;
    bool attacking = false;
    public int attackDamage;
    private int treasure;
    private float direction;
    private Vector3 chestPos; 

    bool isLoading = true;
    

    private IEnumerator attack(Collider2D enemy)
    {
        ai.isStopped=true;
        attacking = true;
        
            GetComponent<PlayerManager>().animator.SetTrigger("Attack");
            enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            
            yield return new WaitForSeconds(1f);
        
        ai.isStopped=false;
        attacking = false;
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
        pickScene();
    }
    private IEnumerator loading()
    {
        yield return new WaitForSeconds(3.0f);
        isLoading = false;
    }
    void Start()
    {
      ai = GetComponent<IAstarAI>();
      rb2d = GetComponent<Rigidbody2D>();
      player = GameObject.FindGameObjectWithTag("Player");
      enemy = GameObject.FindGameObjectsWithTag("Enemy");
      coin = GameObject.FindGameObjectsWithTag("Coin");
      chest = GameObject.FindGameObjectsWithTag("Chest");
      nextLevel = GameObject.FindGameObjectWithTag("NL");
      treasure=chest.Length;
      StartCoroutine(loading());
    }
    void Update()
    {
        
         if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) 
        {
            if(enemy.Length!=0)
            {
             for(int i=0; i < enemy.Length; i++)
             {
                if(enemy[i]!=null)
                {
                  ai.destination = enemy[i].transform.position;
                }
             }
             
            }
            else if(coin.Length!=0){
                for(int i=0; i < coin.Length; i++)
                {
                    if(coin[i]!=null)
                    {
                        ai.destination = coin[i].transform.position;
                    }
                }
            }
            else if(treasure!=0)
            {
                for(int i=0;i<=treasure;i++)
                {
                    foreach (GameObject Chest in chest)
                    {
                        if(Chest.GetComponent<ChestManager>().isOpen==true)
                        {
                           treasure-=1;
                        }
                        
                    }
                    ai.destination = chest[i].transform.position;
                    chestPos = chest[i].transform.position.x - 1;
                }  
            }
            else if(isLoading==false)
            {
              StartCoroutine(wait());
            } 
            ai.SearchPath();

            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            coin = GameObject.FindGameObjectsWithTag("Coin");
        }
        movement.x=ai.desiredVelocity.x;
        movement.y=ai.desiredVelocity.y;
        GetComponent<PlayerManager>().animator.SetFloat("Horizontal", movement.x);
        GetComponent<PlayerManager>().animator.SetFloat("Vertical", movement.y);
        GetComponent<PlayerManager>().animator.SetFloat("Speed", ai.velocity.sqrMagnitude);
        
      

        if(Input.anyKey)
        {
           SceneManager.LoadScene("StartMenu");
        }
        if(player.GetComponent<PlayerManager>().isDead==true)
        {
            ai.isStopped=true;
            GetComponent<PlayerManager>().animator.SetBool("isDead", true);
            StartCoroutine(wait());
        }
        else
        {
            AttackEnemy();
        }

    }
   
    void AttackEnemy()
    {
        
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemies)
            {
                if(attacking==false)
                {
                  StartCoroutine(attack(enemy));
                }
            }
        
            Collider2D[] hitEnemiesl = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemiesl)
            {
                if(attacking==false)
                {
                  StartCoroutine(attack(enemy));
                }
            }
            Collider2D[] hitEnemiest = Physics2D.OverlapCircleAll(attackPointTop.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemiest)
            {
                if(attacking==false)
                {
                  StartCoroutine(attack(enemy));
                }
            }
            Collider2D[] hitEnemiesb = Physics2D.OverlapCircleAll(attackPointBottom.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemiesb)
            {
                if(attacking==false)
                {
                  StartCoroutine(attack(enemy));
                }
            }
        
    }
    void pickScene()
    {
        int scene=0;
        scene=Random.Range(0,2);

        switch (scene)
        {
            case 0:
                SceneManager.LoadScene("DemoMode_level1");
                break;
            case 1:
                SceneManager.LoadScene("DemoMode_level2");
                break;
            default:
                pickScene();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Player collides with chest, if statement is called */
        if(collision.gameObject.name == "Chest" )
        {
            /* Animation is triggered, Item in chest is dropped */
           ai.Teleport(chestPos);
        }
    }
    
}
