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
        season.trucks_data[0].nitroCount++;
        Debug.Log($"Nitro: {season.trucks_data[0].nitroCount}");
    }
}
