using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class upgradeCounter : MonoBehaviour {
    public GameObject playerCurrencyHolder;

    public GameObject pip1;
    public GameObject pip2;
    public GameObject pip3;
    public GameObject pip4;
    public GameObject pip5;
    public GameObject pip6;

    public int currentUpgradeCount = 0;
    public int maxUpgradeCount = 6;
    public int cost = 0;

    private void Awake(){
        updateUpgradeCounter();
    }

    void OnMouseDown(){
        if(playerCurrencyHolder.GetComponent<moneyCounter>().money >= cost && currentUpgradeCount < maxUpgradeCount){
            playerCurrencyHolder.GetComponent<moneyCounter>().money = playerCurrencyHolder.GetComponent<moneyCounter>().money - cost;
            currentUpgradeCount++;
            updateUpgradeCounter();
        }
    }

    private void updateUpgradeCounter(){
        if(currentUpgradeCount > 0){
            pip1.SetActive(true);
        }else{
            pip1.SetActive(false);
        }
        if(currentUpgradeCount > 1){
            pip2.SetActive(true);
        }else{
            pip2.SetActive(false);
        }
        if(currentUpgradeCount > 2){
            pip3.SetActive(true);
        }else{
            pip3.SetActive(false);
        }
        if(currentUpgradeCount > 3){
            pip4.SetActive(true);
        }else{
            pip4.SetActive(false);
        }
        if(currentUpgradeCount > 4){
            pip5.SetActive(true);
        }else{
            pip5.SetActive(false);
        }
        if(currentUpgradeCount > 5){
            pip6.SetActive(true);
        }else{
            pip6.SetActive(false);
        }
    }
}