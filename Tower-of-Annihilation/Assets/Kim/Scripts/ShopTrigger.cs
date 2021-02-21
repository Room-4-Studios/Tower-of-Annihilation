using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private Shop shop;
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        ShopInterface customer = collider.GetComponent<ShopInterface>();
        if (customer != null) 
        {
            shop.Show(customer);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        ShopInterface customer = collider.GetComponent<ShopInterface>();
        if (customer != null)
        {
            shop.Hide();
        }
    }
}
