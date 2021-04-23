using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAssets : MonoBehaviour
{
    private static ShopAssets _i;

    public static ShopAssets i 
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<ShopAssets>("ShopAssets"));
            return _i;
        }
    }

    public Sprite smallHealthPotion;
    public Sprite bigHealthPotion;
    public Sprite hpHeart;
    public Sprite sword;
    public Sprite movePotion;
    public Sprite weaponPotion;
}
