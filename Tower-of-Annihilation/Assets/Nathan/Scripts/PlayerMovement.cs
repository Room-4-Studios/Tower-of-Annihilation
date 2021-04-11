using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float previousMovement; // Checks the last X movement for animator
    public Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // For the animator, Horizontal and vertical movement, and makes sure the character is moving.
        GetComponent<PlayerManager>().animator.SetFloat("Horizontal", movement.x);
        GetComponent<PlayerManager>().animator.SetFloat("Vertical", movement.y);
        GetComponent<PlayerManager>().animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            // Animator setting, checking if the player is moving left or right
            GetComponent<PlayerManager>().animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            previousMovement = Input.GetAxisRaw("Horizontal");
        }

    }

    void FixedUpdate()
    {
        // Player movement based on fixedDeltaTime
        GetComponent<PlayerManager>().rb.MovePosition(GetComponent<PlayerManager>().rb.position+ movement * GetComponent<PlayerManager>().moveSpeed * Time.fixedDeltaTime);
    }

    // Returns the previous X movement for animator
    public float GetPreviousMovement()
    {
        return previousMovement;
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("Spawn").transform.position; 
    }
}
