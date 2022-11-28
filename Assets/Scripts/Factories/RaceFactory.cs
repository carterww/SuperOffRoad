using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
using RaceScripts;

public class RaceFactory
{
    GameObject raceTrack;

    private List<string> trackNames = new List<string>(3);

    public RaceFactory() {
        trackNames.Add("Track_1");
    }

    public Race MakeRace()
    {
        string trackPath = ChooseTrack();
        GameObject r = GameObject.Instantiate((GameObject)Resources.Load(trackPath, typeof(GameObject))) as GameObject;
        r.name = trackPath;
        Debug.Log("made race");
        return new Race(r);
    }

    private string ChooseTrack()
    {
        Random rand = new Random();

        return trackNames[rand.Next(0, trackNames.Count)];
    }

}
