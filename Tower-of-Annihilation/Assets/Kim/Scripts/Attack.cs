using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float Health;
    public Animator animator; //Get player's animations.
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Get the players Rigidbody2D

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Attack");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //ScriptNameHere nom = collision.GetComponent<ScriptNameHere>();

            //Health -= nom.damage;

            //Destroy(nom.gameObject);
        }
    }
}