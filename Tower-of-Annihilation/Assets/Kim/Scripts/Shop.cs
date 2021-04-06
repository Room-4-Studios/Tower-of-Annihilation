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
        UpgradeDMG
    }
    public Item[] itemDB;

    public int[] lootTable =
    { 
        20,
        20, 
        20,
        20
    };

    public static int GetCost(Item itemType)
    {
        switch (itemType)
        {
            default:
            case Item.SmallHealthPotion: return 1;
            case Item.BigHealthPotion: return 4;
            case Item.UpgradeHP: return 10;
            case Item.UpgradeDMG: return 10;
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
        message = GameObject.Find("dialogue");

        //Manually create options.
        /*CreateItemButton(smallHealthPotion, "Small Health Potion", 1, 0);
        CreateItemButton(bigHealthPotion, "Big Health Potion", 4, 1);
        CreateItemButton(hpHeart, "Health Upgrade", 10, 2);
        CreateItemButton(sword, "Damage Upgrade", 11, 3);*/

        //Randomize options.
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

    private void Purchase(string name, int cost) 
    {
        if (customer.AttemptBuy(cost))
        {
            customer.BoughtItem(name, cost);
            message.GetComponent<ShopDialogue>().thankPlayer(name, cost);

            if (name == "Small Health Potion")
                customer.useHealItem(5);
            else if (name == "Big Health Potion")
                customer.useHealItem(10);
            else if (name == "Health Upgrade")
                customer.upgradeHealth();
            else if (name == "Damage Upgrade")
                customer.upgradeDamage();
        }
        else message.GetComponent<ShopDialogue>().insultPlayer(cost);
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
        for (int i = 0; i < 2; i++)
        {
            if (randomNumber <= lootTable[i])
            {
                CreateItemButton(GetSprite(itemDB[i]), GetDesc(itemDB[i]), GetCost(itemDB[i]), i);
                Debug.Log("Randomized an item!");
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

    Item RandomChooser(List<Item> arr)
    {
        int index = Random.Range(0, arr.Count);
        Item value = arr[index];
        arr.RemoveAt(index);
        return value;
    }

}
