using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public float mMovementSpeed = 3f;
    public bool bIsGoingRight = true;
    public float mRaycastingDistance = 1f;
    public Animator animator;

    private SpriteRenderer _mSpriteRenderer;
    Vector2 movement;
    void Start()
    {
        _mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _mSpriteRenderer.flipX = bIsGoingRight;
    }
    void Update()
    {
        Vector3 directionTranslation = (bIsGoingRight) ? transform.right : -transform.right;
        directionTranslation *= Time.deltaTime * mMovementSpeed;

        transform.Translate(directionTranslation);

        CheckForWalls();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
        
    }
    private void CheckForWalls()
    {
        
        Vector3 raycastdirection = (bIsGoingRight) ? Vector3.right : Vector3.left;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastdirection * mRaycastingDistance - new Vector3(0f, 0.25f, 0f), raycastdirection, 0.075f);

        if(hit.collider != null)
        {
            if(hit.transform.tag == "Terrain")
            {
                bIsGoingRight = !bIsGoingRight;

            }
        }
    }
}
