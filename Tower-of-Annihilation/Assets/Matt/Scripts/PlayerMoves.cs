using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 5f;

    public Animator animator;

    Vector2 movement;
   
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
    }
    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
    }
}
