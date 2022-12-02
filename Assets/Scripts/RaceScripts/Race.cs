using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RaceScripts {

public class Race
{
    // track GameObject 
    public GameObject track;

    // Keeps the scores from the trucks from the race
    // Written into object after race ends
    public Dictionary<GameObject, Score> scores = new Dictionary<GameObject, Score>();

    // Write scores from race into dictionary
    public void RaceFinish(List<Score> s)
    {
        Season se = Season.GetInstance();
        for (int i = 0; i < 4; i++)
        {
            this.scores.Add(se.trucks[i], s[i]);
        }
        se.AddRace(this);
    }

    // Constructor that adds track
    public Race(GameObject t) {
        this.track = t;
    }
}

}
