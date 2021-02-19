using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openSprite, closedSprite;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" )
        {
            spriteRenderer.sprite = openSprite;       
        }
    }
}
