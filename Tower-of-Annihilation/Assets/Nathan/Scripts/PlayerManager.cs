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
 
    public int money;
    public bool isDead = false;
    Attack attack;
    private SoundManager sh;

    public int floorsBeaten = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Makes the players current health into the max health
        currentHealth = maxHealth;
        Camera.main.GetComponent<FollowCamera>().player = transform; /*  Follow Camera properly placed on spawning character -Matt */
        attack = GetComponent<Attack>(); //Get Attack script.
        if(GameObject.Find("BCOBJECT").GetComponent<BCMODE>().isBCMode == false)
        {
            Destroy(GameObject.Find("BCOBJECT"));
        }
        else
        {
            EnableBCMode();
            Destroy(GameObject.Find("BCOBJECT"));
        }
    }

    public void TakeDamage(int Damage)
    {
        animator.SetTrigger("Hurt");
        //Debug.Log("Taking Damage");
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
        moveSpeed = 0;
        //attack.attackRate = 0;
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

    public void BoughtItem(string name, int cost) //Successfully bought item.
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

    public void UseHealItem(int healAmount) 
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; //Cap health.
        }
    }

    public void UpgradeHealth()
    {
        maxHealth += 1;
        currentHealth += 1; //Matches max if full health. If not, just give free +10 heal.
    }

    public void UpgradeDamage()
    {
        attack.attackDamage += 1;
    }

    public void UpgradeMoveSpeed()
    {
        moveSpeed += (float)0.1;
    }

    public void UpgradeWeaponSpeed()
    {
        attack.attackRate += (float)0.1;
    }

    public void EnableBCMode()
    {
        maxHealth = 10000000;
        currentHealth = 10000000;
        money = 42;
        attack.attackDamage = 100;
        attack.attackRate += (float)1;
        attack.attackRange = 10;
    }
}
