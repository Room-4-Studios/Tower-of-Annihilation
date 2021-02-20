using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAssets : MonoBehaviour
{
    private static StoreAssets _i;

    public static StoreAssets i //instance
    {
        get {
            if (_i == null) _i = (Instantiate(Resources.Load("StoreAssets")) as GameObject).GetComponent<StoreAssets>();
            return _i;
        }
    }

    public Sprite smallHealthPotion;
    public Sprite bigHealthPotion;

}
