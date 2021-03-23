using System;
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

    /* Checks is chest has been previously opened */
    private bool IsOpen()
    {
        if(isOpen == true)
        {
            return true;
        }
        else
        {
            return false;
        }    
    }

    /* Sets trigger to open for animation */
    private void Animator()
    {
        animator.SetTrigger("Open");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Player collides with chest, if statement is called */
        if(collision.gameObject.name == "Player"  && IsOpen() == false)
        {
            /* Animation is triggered, Item in chest is dropped */
            Animator();
            getItem.ChestDropItem();
            isOpen = true;
        }
    }
}
