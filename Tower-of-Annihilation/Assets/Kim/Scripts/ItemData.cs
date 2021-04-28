using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* Using virtual (and override in Shop.cs),
 * this is an example of dynamic binding.
 */

public class ItemData 
{
    public Sprite defaultSprite;
    public enum Item
    {
        SmallHealthPotion,
        BigHealthPotion,
        UpgradeHP,
        UpgradeDMG,
        UpgradeSpeed,
        UpgradeWeaponSpeed
    }
    public Item[] itemDB;

    public List<Item> NewList()
    {
        itemDB = (Item[])System.Enum.GetValues(typeof(Item));
        List<Item> itemList = new List<Item>(itemDB);
        return itemList;
    }

    public virtual int GetCost(Item itemType) //Get cost of item.
    {
        return 1;
    }
    public virtual Sprite GetSprite(Item itemType) //Get sprite of item.
    {
        return defaultSprite;
    }
    public virtual string GetDesc(Item itemType) //Get description of item.
    {
        return "Default";
    }
}
