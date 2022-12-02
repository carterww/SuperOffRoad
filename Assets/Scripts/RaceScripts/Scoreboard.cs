using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Displays timer to scoreboard
public class Scoreboard : MonoBehaviour
{
    private bool _raceStarted = true;
    public Text text;

    public float RaceTime;

    // Start is called before the first frame update
    void Start()
    {
        this.RaceTime = 0f;
        this.text = GetComponent<Text>();
    }

    // Update timer by adding time between frame
    void Update()
    {
        if (_raceStarted) {
            RaceTime = RaceTime + Time.deltaTime;
        }
        text.text = RaceTime.ToString("0.00");

    }
}