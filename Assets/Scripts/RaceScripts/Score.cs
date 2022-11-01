using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private float time;

    private GameObject truck;

    public float GetTime() { return time; }

    public void SetTime(float t) { this.time = t; }

    public GameObject GetTruck() { return truck; }

    public void SetTruck(GameObject truck) {
        this.truck = truck; 
    }
}
