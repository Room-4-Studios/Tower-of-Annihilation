using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public Animator animator;
    // These are referenced in Unity -Nathan
    // [SerializeField]
    // private SpriteRenderer spriteRenderer;

    // [SerializeField]
    // private Sprite openSprite, closedSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" )
        {
            animator.SetTrigger("Open");
            //GetComponent<Animator>().enabled = false;
            //Destroy(gameObject);
        }
    }
}
