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

    public float RaceTime;

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
}