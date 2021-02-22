using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
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

    public void DropItem()
    {
        randNum = Random.Range(0,101); 
        Debug.Log("Random number is " + randNum);

        if (randNum >= 0)
        {
            itemNum = 0;
            Instantiate(itemList[itemNum], dropPos.position, Quaternion.identity);
        }
    }

    public void ChestDropItem()
    {
        randNum = Random.Range(0,101); 
        Debug.Log("Random number is " + randNum);

        if (randNum >= 0)
        {
            itemNum = 0;
            Instantiate(itemList[itemNum], dropPos.position, Quaternion.identity);
        }
    }
}