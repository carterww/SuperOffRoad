using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    // starts timer 
    private bool _raceStarted = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (_raceStarted) {
            RaceTime += Time.deltaTime;
        }
    }
}
