using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : PickupItem
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Picked Up Potion");
        if(other.CompareTag("Player"))
            {
                for(int i = 0; i < inventory.slots.Length; i++)
                {
                    if(inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        Instantiate(itemButton, inventory.slots[i].transform, false);
                        FindObjectOfType<SoundManager>().Play("Pickup Potion");
                        Destroy(gameObject);
                        break;
                    }
                }
            }
    }
}

