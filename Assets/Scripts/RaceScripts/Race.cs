using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RaceScripts {

public class Race
{
    public GameObject track;
    public Dictionary<GameObject, Score> scores = new Dictionary<GameObject, Score>();

    // Subscriber to event OnRaceFinish and takes a dictionary of <GameObject(Truck), Score>
    // Score contains the time and placement of the truck
    public void RaceFinish(List<Score> s)
    {
        Season se = Season.GetInstance();
        for (int i = 0; i < 4; i++)
        {
            this.scores.Add(se.trucks[i], s[i]);
        }
        se.AddRace(this);
    }

    public Race(GameObject t) {
        this.track = t;
    }
}

}
