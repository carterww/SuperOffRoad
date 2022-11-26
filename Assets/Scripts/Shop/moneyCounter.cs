using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
 
public class moneyCounter : MonoBehaviour {
    public TMP_Text currentMoney;
 
    public int money = 0;
 
    private void Awake(){
        currentMoney = GetComponent<TMP_Text>();
        currentMoney.text = money.ToString();
    }

    void Update () {
        currentMoney.text = money.ToString();
        //money++; originally used for testing
    }
}