using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
using RaceScripts;

// Factory responsible creating the Track GameObject
// Makes a new Race object with the track
public class RaceFactory
{
    GameObject raceTrack;

    private List<string> trackNames = new List<string>(3);

    // Adds list of tracks to array
    public RaceFactory() {
        trackNames.Add("Track_1");
    }

    // Makes track and race
    public Race MakeRace()
    {
        string trackPath = ChooseTrack();
        GameObject r = GameObject.Instantiate((GameObject)Resources.Load(trackPath, typeof(GameObject))) as GameObject;
        r.name = trackPath;
        Debug.Log("made race");
        return new Race(r);
    }

    // Randomly chooses a track from the array of track names
    private string ChooseTrack()
    {
        Random rand = new Random();

        return trackNames[rand.Next(0, trackNames.Count)];
    }

}
