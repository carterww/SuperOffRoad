using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    // starts timer 
    private bool _raceStarted = true;
    public Text text;

    float RaceTime;

    // Start is called before the first frame update
    void Start()
    {
        this.RaceTime = 0f;
        this.text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_raceStarted) {
            RaceTime = RaceTime + Time.deltaTime;
        }
        text.text = RaceTime.ToString("0.00");

    }

    // handles the event OnRaceStart and simply starts timer and adds lap and nitro counnt
    private void StartTimer_OnRaceStart(object sender, OnRaceStartEventArgs e)
    {
        _raceStarted = true;
        /*foreach (GameObject truck in e.trucks)
        {
            _lapCounters.Add(truck, 1);

            // TODO grab nitro count from truckcontroller
            _nitroCounters.Add(truck, 1);
        }*/
    }
}