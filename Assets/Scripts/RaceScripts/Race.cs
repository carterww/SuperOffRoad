using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RaceScripts {

public class Race
{
    GameObject track;
    public Dictionary<GameObject, Score> scores = new Dictionary<GameObject, Score>();

    // Subscriber to event OnRaceFinish and takes a dictionary of <GameObject(Truck), Score>
    // Score contains the time and placement of the truck
    private void WriteRace_OnRaceFinish(object sender, OnRaceFinishEventArgs e)
    {
        this.scores = e.scores;
        Season s = Season.GetInstance();
        s.AddRace(this);
    }

    public Race(GameObject t) {
        this.track = t;
    }
}

}
