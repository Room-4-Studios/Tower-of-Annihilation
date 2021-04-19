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
                for(int i = 0; i < inventory.slots.Length; i++) // Looks at each of the Player's inventory slots. 
                {
                    if(inventory.isFull[i] == false)    // Checks if i item slot has an item in it.
                    {
                        inventory.isFull[i] = true; // Sets the inventory slot to full.
                        Instantiate(itemButton, inventory.slots[i].transform, false);   // Creates the picked up items button. 
                        FindObjectOfType<SoundManager>().Play("Pickup Potion"); // Plays the potion pickup sound.
                        Destroy(gameObject); // Destroy the item in the scene.
                        break;
                    }
                }
            }
    }
}

