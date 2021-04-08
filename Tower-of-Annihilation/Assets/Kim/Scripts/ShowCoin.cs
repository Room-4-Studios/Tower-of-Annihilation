using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowCoin : MonoBehaviour
{
    //public PlayerManager mgmt;
    GameObject mgmt;
    public TMP_Text coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        mgmt = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //coinAmount.text = (mgmt.CurrentMoney()).ToString();
        //mgmt = GameObject.Find("Player");
        coinAmount.text = (mgmt.GetComponent<PlayerManager>().CurrentMoney()).ToString();
    }
}
