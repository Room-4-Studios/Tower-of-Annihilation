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
        if(collision.gameObject.name == "Player"  && isOpen == false)
        {
            animator.SetTrigger("Open");
            getItem.ChestDropItem();
            isOpen = true;
        }
    }
}
