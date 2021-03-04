using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class Shop : MonoBehaviour
{
    public Sprite smallHealthPotion;
    public Sprite bigHealthPotion;
    public Sprite hpHeart;
    private Transform container;
    private Transform shopItemTemplate;

    private ShopInterface customer;

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
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
