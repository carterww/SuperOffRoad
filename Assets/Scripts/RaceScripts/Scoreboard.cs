using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    // starts timer 
    private bool _raceStarted = false;
    private Dictionary<GameObject, int> _lapCounters;
    private Dictionary<GameObject, int> _nitroCounters;

    public float RaceTime
    {
        get { return RaceTime; }
        set
        {
            RaceTime = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.RaceTime = 0f;
        this._lapCounters = new Dictionary<GameObject, int>();
        this._nitroCounters = new Dictionary<GameObject, int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_raceStarted) {
            RaceTime += Time.deltaTime;
        }
    }

    // handles the event OnRaceStart and simply starts timer and adds lap and nitro counnt
    private void StartTimer_OnRaceStart(object sender, OnRaceStartEventArgs e)
    {
        _raceStarted = true;
        foreach (GameObject truck in e.trucks)
        {
            _lapCounters.Add(truck, 1);

            // TODO grab nitro count from truckcontroller
            _nitroCounters.Add(truck, 1);
        }
    }
}