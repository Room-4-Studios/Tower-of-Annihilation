using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PickupItem
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Picked Up Coin");
        if(other.CompareTag("Player"))
        {
            playerMgmt.SendMessage("Money");
            FindObjectOfType<SoundManager>().Play("Pickup Coin");
            Destroy(gameObject);
        }
    }
}
