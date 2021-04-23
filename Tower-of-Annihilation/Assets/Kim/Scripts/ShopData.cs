using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData : ItemData
{
    public override int GetCost(Item itemType)
    {
        switch (itemType)
        {
            default:
            case Item.SmallHealthPotion: return 1;
            case Item.BigHealthPotion: return 4;
            case Item.UpgradeHP: return 10;
            case Item.UpgradeDMG: return 10;
            case Item.UpgradeSpeed: return 4;
            case Item.UpgradeWeaponSpeed: return 4;
        }
    }
    public override Sprite GetSprite(Item itemType)
    {
        switch (itemType)
        {
            default:
            case Item.SmallHealthPotion: return ShopAssets.i.smallHealthPotion;
            case Item.BigHealthPotion: return ShopAssets.i.bigHealthPotion;
            case Item.UpgradeHP: return ShopAssets.i.hpHeart;
            case Item.UpgradeDMG: return ShopAssets.i.sword;
            case Item.UpgradeSpeed: return ShopAssets.i.movePotion;
            case Item.UpgradeWeaponSpeed: return ShopAssets.i.weaponPotion;
        }
    }
    public override string GetDesc(Item itemType)
    {
        switch (itemType)
        {
            default:
            case Item.SmallHealthPotion: return "Small Health Potion";
            case Item.BigHealthPotion: return "Big Health Potion";
            case Item.UpgradeHP: return "Health Upgrade";
            case Item.UpgradeDMG: return "Damage Upgrade";
            case Item.UpgradeSpeed: return "Move Speed Upgrade";
            case Item.UpgradeWeaponSpeed: return "Weapon Speed Upgrade";
        }
    }
}
