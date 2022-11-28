using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RaceScripts;

public class ReloadTrucks : MonoBehaviour
{
    void Start()
    {
        ReloadTrucksForRace();
    }

    public static void ReloadTrucksForRace()
    {
        Season s = Season.GetInstance();
        
        s.StartNewRace();
    }
}
