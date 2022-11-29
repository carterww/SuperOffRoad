using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using RaceScripts;

public class DoneShopping : MonoBehaviour
{
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        ReloadTrucksForRace();
    }

    // Starts the next race
    void ReloadTrucksForRace()
    {
        Season.GetInstance().StartNewRace();
    }
}