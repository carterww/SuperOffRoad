using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private float time;

    private GameObject truck;

    public float GetTime() { return time; }

    public float SetTime(float t) { this.time = t; }

    public float GetTruck() { return truck; }

    public float SetTruck(GameObject truck) {
        this.truck = truck; 
    }
}
