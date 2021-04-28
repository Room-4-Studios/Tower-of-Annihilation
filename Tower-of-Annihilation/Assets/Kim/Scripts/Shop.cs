using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class Shop : MonoBehaviour
{
    //Sprites

    public Sprite smallHealthPotion;
    public Sprite bigHealthPotion;
    public Sprite hpHeart;
    public Sprite sword;
    public Sprite movePotion;
    public Sprite weaponPotion;

    //Other

    private Transform container;
    private Transform shopItemTemplate;

    private ShopInterface customer;
    GameObject message;

    public int total;
    public int randomNumber;

    //Item database

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

    public static int GetCost(Item itemType)
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
    public Sprite GetSprite(Item itemType)
    {
        switch (itemType)
        {
            default:
            case Item.SmallHealthPotion: return smallHealthPotion;
            case Item.BigHealthPotion: return bigHealthPotion;
            case Item.UpgradeHP: return hpHeart;
            case Item.UpgradeDMG: return sword;
            case Item.UpgradeSpeed: return movePotion;
            case Item.UpgradeWeaponSpeed: return weaponPotion;
        }
    }
    public string GetDesc(Item itemType)
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

    //Shop functions

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);
    }

    private void Start() //Create two random shop item buttons.
    {
        message = GameObject.Find("dialogue");

        //Manually create options.
        /*CreateItemButton(smallHealthPotion, "Small Health Potion", 1, 0);
        CreateItemButton(bigHealthPotion, "Big Health Potion", 4, 1);
        CreateItemButton(hpHeart, "Health Upgrade", 10, 2);
        CreateItemButton(sword, "Damage Upgrade", 11, 3);*/

        //Randomize options.
        //ShopData.List<Item> listt = ShopData.NewList();
        itemDB = (Item[])System.Enum.GetValues(typeof(Item));
        List<Item> itemList = new List<Item>(itemDB);
        Item item1 = RandomChooser(itemList);
        Item item2 = RandomChooser(itemList);
        CreateItemButton(GetSprite(item1), GetDesc(item1), GetCost(item1), 0);
        CreateItemButton(GetSprite(item2), GetDesc(item2), GetCost(item2), 1);
        Hide();
    }


    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 70f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
        shopItemTransform.Find("itemDesc").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("itemCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImag").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            Purchase(itemName, itemCost);
        };
    }

    private void Purchase(string name, int cost) //Attempt to purchase shop items and use them.
    {
        if (customer.AttemptBuy(cost))
        {
            customer.BoughtItem(name, cost);
            message.GetComponent<ShopDialogue>().ThankPlayer(name, cost);

            if (name == "Small Health Potion")
                customer.UseHealItem(2);
            else if (name == "Big Health Potion")
                customer.UseHealItem(5);
            else if (name == "Health Upgrade")
                customer.UpgradeHealth();
            else if (name == "Damage Upgrade")
                customer.UpgradeDamage();
            else if (name == "Move Speed Upgrade")
                customer.UpgradeMoveSpeed();
            else if (name == "Weapon Speed Upgrade")
                customer.UpgradeWeaponSpeed();
        }
        else message.GetComponent<ShopDialogue>().InsultPlayer(cost);
    }

    public void Show(ShopInterface customer) 
    {
        this.customer = customer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    Item RandomChooser(List<Item> arr)
    {
        int index = Random.Range(0, arr.Count);
        Item value = arr[index];
        arr.RemoveAt(index);
        return value;
    }

}
