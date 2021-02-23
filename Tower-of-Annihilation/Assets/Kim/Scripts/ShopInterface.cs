using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShopInterface 
{
    void BoughtItem(string name, int cost);
    bool AttemptBuy(int cost);
}
