using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float moveSpeed;
    // public Rigidbody2D rb;
    //public Animator animator;
    //public Transform player;

    private float previousMovement;
    public Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        GetComponent<PlayerManager>().animator.SetFloat("Horizontal", movement.x);
        GetComponent<PlayerManager>().animator.SetFloat("Vertical", movement.y);
        GetComponent<PlayerManager>().animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            GetComponent<PlayerManager>().animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            previousMovement = Input.GetAxisRaw("Horizontal");
        }

    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * GetComponent<PlayerManager>().moveSpeed * Time.fixedDeltaTime);
        GetComponent<PlayerManager>().rb.MovePosition(GetComponent<PlayerManager>().rb.position+ movement * GetComponent<PlayerManager>().moveSpeed * Time.fixedDeltaTime);
    }

    public float GetPreviousMovement()
    {
        return previousMovement;
    }
}
