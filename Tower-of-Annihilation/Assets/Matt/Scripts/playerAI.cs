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
    public LayerMask enemylair;
    public int attackDamage;
    private int treasure;
    private float direction;
    

    private IEnumerator stop()
    {
        ai.isStopped=true;
        yield return new WaitForSeconds(0.75f);
        ai.isStopped=false;
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
        pickScene();
    }
    void Start()
    {
      ai = GetComponent<IAstarAI>();
      rb2d = GetComponent<Rigidbody2D>();
      enemy = GameObject.FindGameObjectsWithTag("Enemy");
      coin = GameObject.FindGameObjectsWithTag("Coin");
      chest = GameObject.FindGameObjectsWithTag("Chest");
      nextLevel = GameObject.FindGameObjectWithTag("NL");
      treasure=chest.Length;
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
            /*else if(treasure!=0)
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
                }  
            }*/
            else
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
        
        AttackEnemy();

        if(Input.anyKey)
        {
           SceneManager.LoadScene("StartMenu");
        }
        if(GetComponent<PlayerManager>().dead==true)
        {
            ai.isStopped=true;
        }

    }
   
    void AttackEnemy()
    {
        
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylair);
            foreach(Collider2D enemy in hitEnemies)
            {
                StartCoroutine(stop());
                GetComponent<PlayerManager>().animator.SetTrigger("Attack");
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                
            }
        
            Collider2D[] hitEnemiesl = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemylair);
            foreach(Collider2D enemy in hitEnemiesl)
            {
                StartCoroutine(stop());
                GetComponent<PlayerManager>().animator.SetTrigger("Attack");
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                
            }
            Collider2D[] hitEnemiest = Physics2D.OverlapCircleAll(attackPointTop.position, attackRange, enemylair);
            foreach(Collider2D enemy in hitEnemiest)
            {
                StartCoroutine(stop());
                GetComponent<PlayerManager>().animator.SetTrigger("Attack");
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
               
            }
            Collider2D[] hitEnemiesb = Physics2D.OverlapCircleAll(attackPointBottom.position, attackRange, enemylair);
            foreach(Collider2D enemy in hitEnemiesb)
            {
                StartCoroutine(stop());
                GetComponent<PlayerManager>().animator.SetTrigger("Attack");
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                
            }
        
    }
    void pickScene()
    {
        int scene=0;
        scene=Random.Range(0,0);

        switch (scene)
        {
            case 0:
                SceneManager.LoadScene("Demo_Mode_Pass");
                break;
            default:
                pickScene();
                break;
        }
    }
   
    
    
}
