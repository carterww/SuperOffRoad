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
        string trackPath = "prefabs/" + ChooseTrack();
        return new Race((GameObject)Resources.Load(trackPath, typeof(GameObject)));
    }

    private string ChooseTrack()
    {
        Random rand = new Random();

        return trackNames[rand.Next(0, trackNames.Count)];
    }

}
