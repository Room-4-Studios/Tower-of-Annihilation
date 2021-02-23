using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowCoin : MonoBehaviour
{
    public PlayerManager mgmt;
    public TMP_Text coinAmount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coinAmount.text = (mgmt.CurrentMoney()).ToString();
    }
}
