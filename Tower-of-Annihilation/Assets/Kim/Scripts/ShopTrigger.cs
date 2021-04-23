using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Prefab instructions:
 * 
 * This script is connected to the shopkeeper prefab. 
 * Please fill in the Shop.cs location in the Inspector for this script.
 * The Shop.cs location is in the provided Canvas prefab in the "Shop" object.
 *  
 * Prefab behavior: 
 * If the player gets within range of the shopkeeper's collider, show the shop menu items created by Shop.cs.
 * It also enables the shop dialogue from ShopDialogue.cs to be shown.
 * If the player gets out of the shopkeeper's collider, the shop menu items and dialogue will be hidden.
 * The player's PlayerManager will inherit the methods from the interface ShopInterface.
 * ShopInterface generally serves as a leeway between Shop.cs and PlayerManager.cs so that data can be passed properly.
 */

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private Shop shop;
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        ShopInterface customer = collider.GetComponent<ShopInterface>(); //Get shop interface.
        if (customer != null) 
        {
            shop.Show(customer); //Show the shop.
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        ShopInterface customer = collider.GetComponent<ShopInterface>();
        if (customer != null)
        {
            shop.Hide(); //Hide the shop.
        }
    }
}
