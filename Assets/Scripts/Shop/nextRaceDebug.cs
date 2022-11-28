using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
 
public class nextRaceDebug : MonoBehaviour {
    public GameObject playerCurrencyHolder;
    //public int currentUpgradeCount = 0;
    //public int maxUpgradeCount = 6;
    //public int cost = 0;

//    void Update () {
//        localMoney = playerCurrencyHolder.money;
//    }

    void OnMouseDown(){
        playerCurrencyHolder.GetComponent<moneyCounter>().money = playerCurrencyHolder.GetComponent<moneyCounter>().money + 10000;
    }
}