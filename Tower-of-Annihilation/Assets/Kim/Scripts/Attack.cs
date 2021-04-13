using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange;
    public Transform attackPoint;
    public Transform attackPointLeft;
    public LayerMask enemyLayer;
    private float nextAttackTime = 0f;
    public float attackRate;
    public int attackDamage;
    private SoundManager sh;

    // Start is called before the first frame update
    void Start()
    {
        sh = GetComponent<SoundManager>();
        GetComponent<PlayerManager>().rb = GetComponent<Rigidbody2D>(); //Get the players Rigidbody2D 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime && GetComponent<PlayerManager>().isDead == false)
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
        GetComponent<PlayerManager>().animator.SetTrigger("Attack");
        FindObjectOfType<SoundManager>().Play("Player Attack");
        if(GetComponent<PlayerMovement>().GetPreviousMovement() == 1)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            }
        }
        else if(GetComponent<PlayerMovement>().GetPreviousMovement() == -1)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            }
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

    public void IncreaseAttackDmg(int dmg)
    {
        attackDamage += dmg;
    }

}