using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, ShopInterface
{
    public float moveSpeed;
    public Animator animator;
    public Transform player;
    public Rigidbody2D rb;

    public int maxHealth;
    public int currentHealth;
    private int numberOfHearts;

    public int money;
    public bool isDead = false;

    Attack attack;

    private SoundManager sh;

    /* Audio Changes were done by Scott if you have questions */
    /* Moved to SOUNDMANAGER.CS */
    // public AudioSource coinAud;
    // public AudioClip coinSound;
    // public AudioSource buyAud;
    // public AudioClip coinSound2;
    // public AudioSource damageAud;
    // public AudioClip damageSound;

    // Start is called before the first frame update
    void Start()
    {
        // Makes the players current health into the max health
        
        currentHealth = maxHealth;
        numberOfHearts = maxHealth;
        Camera.main.GetComponent<FollowCamera>().player = transform; /*  Follow Camera properly placed on spawning character -Matt */
        attack = GetComponent<Attack>(); //Get Attack script.
    }

    public void TakeDamage(int Damage)
    {
        animator.SetTrigger("Hurt");
        Debug.Log("Taking Damage");
        FindObjectOfType<SoundManager>().Play("Player Hurt");
        currentHealth -= Damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    // When the player dies, sets the animation to play
    public void Die()
    {
        animator.SetBool("isDead", true);
        isDead = true;
    }

    //Regarding purchasing items.
    public int CurrentMoney() //For showing coins on screen.
    {
        return money;
    }

    public void Money() //Increase coin amount if pick up coin.
    {
        //coinAud.PlayOneShot(coinSound);
        money++; 
    }

    public void BoughtItem(string name, int cost)
    {
        Debug.Log("Bought: " + name + " with " + cost + " gold.");
        FindObjectOfType<SoundManager>().Play("Purchase Item");
    }

    public bool AttemptBuy(int cost)
    {
        if (money >= cost) //Enough money.
        {
            money -= cost;
            //buyAud.PlayOneShot(coinSound2);
            return true;
        }
        else //Not enough money.
        { 
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
