using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // Each object prefab is going to placed into this field in unity
    [SerializeField]
    private GameObject[] itemList;
    private int itemNum; // selects a number to chose from the itemList.
    private int randNum; // cooses a random number to see loot dropped.
    private Transform dropPos; // position of loot

    // Start is called before the first frame update
    void Start()
    {
        dropPos = GetComponent<Transform>();
        Debug.Log(itemList);
    }

    // Grabs a random item from the item list and puts it onto the map
    public void DropItem()
    {
        randNum = Random.Range(0,101); 
        //Debug.Log("Random number is " + randNum);

        if (randNum >= 0)
        {
            itemNum = 0;
            Instantiate(itemList[itemNum], dropPos.position, Quaternion.identity);
        }
    }
    // Grabs a random item from the item list for chests to drop
    public void ChestDropItem()
    {
        randNum = Random.Range(0,101); 
        //Debug.Log("Random number is " + randNum);

        if (randNum >= 0)
        {
            itemNum = 0;
            Instantiate(itemList[itemNum], dropPos.position, Quaternion.identity);
        }
    }
}