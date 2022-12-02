using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holds score information for a truck
public class Score
{
    private float time;

    public int place;

    public Score(float t, int place)
    {
        this.time = t;
        this.place = place;
    }

    public float GetTime() { return time; }

    public void SetTime(float t) { this.time = t; }
}
