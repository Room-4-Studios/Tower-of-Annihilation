﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public Animator animator;
    private ItemDrop getItem;
    public static ChestManager checker;
    public bool isOpen = false; /*Made Public so its accesible outside class for PlayerAI */

    void Start()
    {
        getItem = GetComponent<ItemDrop>();
    }

    /* Checks is chest has been previously opened */
    public bool IsOpen()
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
    private void AnimateObject()
    {
        animator.SetTrigger("Open");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Player collides with chest, if statement is called */
        if((collision.gameObject.name == "Player" || collision.gameObject.name == "PlayerAI")  && IsOpen() == false)
        {
            /* Animation is triggered, Item in chest is dropped */
            AnimateObject();
            FindObjectOfType<SoundManager>().Play("Open Chest");
            getItem.ChestDropItem();
            isOpen = true;
        }
    }
}
