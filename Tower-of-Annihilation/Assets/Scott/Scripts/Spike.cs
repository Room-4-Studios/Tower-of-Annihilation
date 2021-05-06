using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform player;
    public int spikeDamage;
    public Animator animator;
    private bool isActive = false;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive == false)
        {
            animator.SetBool("Activated", true);
            isActive = true;
            Debug.Log("Trap Activated");
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive == true)
        {
            player.GetComponent<PlayerManager>().TakeDamage(spikeDamage);
        }
    }
}
