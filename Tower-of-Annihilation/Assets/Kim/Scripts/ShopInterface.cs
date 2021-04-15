﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShopInterface 
{
    void BoughtItem(string name, int cost);
    bool AttemptBuy(int cost);
    void UseHealItem(int healAmount);
    void UpgradeHealth();
    void UpgradeDamage();
    void UpgradeMoveSpeed();
    void UpgradeWeaponSpeed();
}
