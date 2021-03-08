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

    //Other

    private Transform container;
    private Transform shopItemTemplate;

    private ShopInterface customer;

    public int total;
    public int randomNumber;

    //Item database

    public enum Item
    {
        SmallHealthPotion,
        BigHealthPotion,
        UpgradeHP
    }
    public Item[] itemDB;

    public int[] lootTable =
    { 
        10,
        30, 
        10
    };

    public static int GetCost(Item itemType)
    {
        switch (itemType)
        {
            default:
            case Item.SmallHealthPotion: return 1;
            case Item.BigHealthPotion: return 4;
            case Item.UpgradeHP: return 10;
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
        }
    }

    //Shop functions

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);
    }

    private void Start()
    {
        CreateItemButton(smallHealthPotion, "Small Health Potion", 1, 0);
        CreateItemButton(bigHealthPotion, "Big Health Potion", 4, 1);
        CreateItemButton(hpHeart, "Health Upgrade", 10, 2);
        itemDB = (Item[])System.Enum.GetValues(typeof(Item));
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

    private void Purchase(string name, int cost) 
    {
        if (customer.AttemptBuy(cost))
        {
            customer.BoughtItem(name, cost);
            if (name == "Small Health Potion")
                customer.useHealItem(5);
            else if (name == "Big Health Potion")
                customer.useHealItem(10);
            else if (name == "Health Upgrade")
                customer.upgradeHealth();
        }
    }

    public void Show(ShopInterface customer) 
    {
        this.customer = customer;
        gameObject.SetActive(true);
        /*foreach (var item in lootTable)
        {
            total += item;
        }
        randomNumber = Random.Range(0, total);
        for (int i = 0; i < lootTable.Length; i++)
        {
            if (randomNumber <= lootTable[i])
            {
                CreateItemButton(GetSprite(itemDB[i]), GetDesc(itemDB[i]), GetCost(itemDB[i]), 0);
                Debug.Log("Randomized an item!");
                return;
            }
            else
            {
                randomNumber -= lootTable[i];
            }
        }*/
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
