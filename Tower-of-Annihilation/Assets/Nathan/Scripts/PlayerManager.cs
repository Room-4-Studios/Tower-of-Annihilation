using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ShopInterface
{
    public float moveSpeed;
    public Animator animator;
    public Transform player;
    public Rigidbody2D rb;
    public int maxHealth;
    public int currentHealth; 
    public int money;
    public bool dead = false;

    public Attack attack;
    public ShopDialogue message;

    /* Audio Changes were done by Scott if you have questions */
    public AudioSource coinAud;
    public AudioClip coinSound;
    public AudioSource buyAud;
    public AudioClip coinSound2;
    public AudioSource damageAud;
    public AudioClip damageSound;

    // Start is called before the first frame update
    void Start()
    {
        // Makes the players current health into the max health
        
        currentHealth = maxHealth;
        Camera.main.GetComponent<FollowCamera>().player = transform; /*  Follow Camera properly placed on spawning character -Matt */
        coinAud = GetComponent<AudioSource>();
        buyAud = GetComponent<AudioSource>();
        damageAud = GetComponent<AudioSource>();
    }

    public void TakeDamage(int Damage)
    {
        animator.SetTrigger("Hurt");
        Debug.Log("Taking Damage");
        currentHealth -= Damage;
        damageAud.PlayOneShot(damageSound);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    // When the player dies, sets the animation to play
    public void Die()
    {
        animator.SetBool("isDead", true);
        dead=true;
    }

    //Regarding purchasing items.
    public int CurrentMoney() //For showing coins on screen.
    {
        return money;
    }

    public void Money() //Increase coin amount if pick up coin.
    {
        coinAud.PlayOneShot(coinSound);
        money++; 
    }

    public void BoughtItem(string name, int cost)
    {
        Debug.Log("Bought: " + name + " with " + cost + " gold.");
        message.thankPlayer(name, cost);
    }

    public bool AttemptBuy(int cost)
    {
        if (money >= cost) //Enough money.
        {
            money -= cost;
            buyAud.PlayOneShot(coinSound2);
            return true;
        }
        else //Not enough money.
        { 
            message.insultPlayer(cost, money);
            return false;
        }

    }

    public void useHealItem(int healAmount) 
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth; //Cap health.
    }

    public void upgradeHealth()
    {
        maxHealth += 10;
        currentHealth += 10; //Matches max if full health. If not, just give free +10 heal.
    }

    public void upgradeDamage()
    {
        attack.attackDamage+=10;
    }
}
