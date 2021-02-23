using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject mgmt;
    private Transform player;
    private float dist;
    public float speed;
    public float followDistance;

    // Start is called before the first frame update
    void Start()
    {
        mgmt = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(player.position, transform.position);
        if(dist <= followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mgmt.SendMessage("Money");
            Destroy(gameObject);
        }
    }
}
