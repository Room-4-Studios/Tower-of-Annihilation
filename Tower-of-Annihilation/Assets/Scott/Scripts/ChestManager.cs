using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public Animator animator;
    private ItemDrop getItem;
    private bool isOpen = false;

    void Start()
    {
        getItem = GetComponent<ItemDrop>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Player collides with chest, if statement is called */
        if(collision.gameObject.name == "Player"  && isOpen == false)
        {
            /* Animation is triggered, Item in chest is dropped */
            animator.SetTrigger("Open");
            getItem.ChestDropItem();
            isOpen = true;
        }
    }
}
