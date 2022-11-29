using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RaceScripts;

public class UpgradeButton : MonoBehaviour
{
    public int upgradeIndex;
    
    GameObject pip1;
    GameObject pip2;
    GameObject pip3;
    GameObject pip4;
    GameObject pip5;
    Season season;
    
    // Start is called before the first frame update
    void Start()
    {
        season = Season.GetInstance();
        
        Button btn = gameObject.GetComponentInChildren(typeof(Button)) as Button;
        btn.onClick.AddListener(OnClick);

        pip1 = transform.Find("Pip1").gameObject;
        pip2 = transform.Find("Pip2").gameObject;
        pip3 = transform.Find("Pip3").gameObject;
        pip4 = transform.Find("Pip4").gameObject;
        pip5 = transform.Find("Pip5").gameObject;
        FixPipBarValue(season.trucks_data[0].upgrades[upgradeIndex]);
    }

    private void OnClick()
    {
        if (season.trucks_data[0].upgrades[upgradeIndex] < 5) {
            season.trucks_data[0].upgrades[upgradeIndex]++;
            FixPipBarValue(season.trucks_data[0].upgrades[upgradeIndex]);
            Debug.Log($"Upgrades: {season.trucks_data[0].upgrades[0]}, {season.trucks_data[0].upgrades[1]}, {season.trucks_data[0].upgrades[2]}, {season.trucks_data[0].upgrades[3]}, {season.trucks_data[0].upgrades[4]}");

        }
    }

    private void FixPipBarValue(int value)
    {
        SetPipShow(pip1, false);
        SetPipShow(pip2, false);
        SetPipShow(pip3, false);
        SetPipShow(pip4, false);
        SetPipShow(pip5, false);
        if (value > 0) SetPipShow(pip1, true);
        if (value > 1) SetPipShow(pip2, true);
        if (value > 2) SetPipShow(pip3, true);
        if (value > 3) SetPipShow(pip4, true);
        if (value > 4) SetPipShow(pip5, true);
    }

    // Set if pip should show
    private void SetPipShow(GameObject pip, bool show)
    {
        pip.GetComponent<Image>().enabled = show;
    }
}
