using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public GameObject mngr;
    GameObject mngr=null;

    // Start is called before the first frame update
    void Start()
    {
        mngr = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mngr.SendMessage("Money");
            Destroy(gameObject);
        }
    }
}
