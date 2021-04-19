using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    protected Inventory inventory;
    protected Transform player;
    public GameObject playerMgmt;
    public GameObject itemButton;
    public float dist;
    public float speed;
    public float followDistance;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMgmt = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        dist = Vector2.Distance(player.position, transform.position);
        if(dist <= followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Item Picked up");
    }
}