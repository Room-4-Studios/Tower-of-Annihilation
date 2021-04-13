using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlotManager : MonoBehaviour
{
    private Inventory inventory;
    public int inventoryPosition;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.childCount <= 0)
       {
           inventory.isFull[inventoryPosition] = false;
       } 
    }
}
