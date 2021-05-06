using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    protected Inventory inventory;    // References the Player's Inventory.
    protected Transform player;    // References the Player's Transform.
    public GameObject playerMgmt;    // References the Player's PlayerManager Script.
    public GameObject itemButton;   // The PickupItem's inventory button.
    private float dist;     // Distance between Pickup Item and Player's Transform.
    public float speed;     // Speed in which item goes towards player.
    public float followDistance;    // Distance in which the item follows the player.

    protected virtual void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();   // Sets inventory to the Player's Inventory
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Sets players(transform) position
        playerMgmt = GameObject.FindGameObjectWithTag("Player");        // Grabs the player game manager for coins
    }

    protected virtual void Update()
    {
        dist = Vector2.Distance(player.position, transform.position);   // Every frame, sets "dist" to the distance between the player and the pickupable object
        if(dist <= followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);  // Move the object closer to the player.
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)   // This is the primary function that is changed in class to class basis. 
    {
        Debug.Log("Item Picked up");
    }
}