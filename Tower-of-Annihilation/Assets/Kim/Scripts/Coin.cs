using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject mgmt;

    // Start is called before the first frame update
    void Start()
    {
        mgmt = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

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
