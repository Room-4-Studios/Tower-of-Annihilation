using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // Each object prefab is going to placed into this field in unity
    [SerializeField]
    private GameObject[] itemList;
    private Transform dropPos; // position of loot

    // Start is called before the first frame update
    void Start()
    {
        dropPos = GetComponent<Transform>();
    }

    // Grabs a random item from the item list and puts it onto the map
    public void DropItem()
    {
        Instantiate(itemList[Random.Range(0,itemList.Length)], dropPos.position, Quaternion.identity);
    }
    // Grabs a random item from the item list for chests to drop
    public void ChestDropItem()
    {
        Instantiate(itemList[Random.Range(0,itemList.Length)], dropPos.position, Quaternion.identity);
    }
}