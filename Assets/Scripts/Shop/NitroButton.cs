using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RaceScripts;

public class NitroButton : MonoBehaviour
{
    Season season;
    
    // Start is called before the first frame update
    void Start()
    {
        season = Season.GetInstance();
        
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {   
        if (season.trucks_data[0].money < 10000) return;
        season.trucks_data[0].nitroCount++;
        season.trucks_data[0].money = season.trucks_data[0].money - 10000;
        Debug.Log($"Nitro: {season.trucks_data[0].nitroCount}");
    }
}
