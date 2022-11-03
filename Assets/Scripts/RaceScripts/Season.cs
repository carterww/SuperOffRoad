using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaceScripts {

// Class that represents a season in Super Off Road
// Implemented as a singleton because only one season can take place at a time
// Holds relevant information about the season
public class Season
{
    private static Season season = null;

    public const int maxNumOfRaces = 20;

    List<Race> raceHistory = new List<Race>(maxNumOfRaces);

    Race currentRace = null;
    List<GameObject> trucks = new List<GameObject>(4);

    private Season() {}

    public static Season GetInstance() {
        if (season == null) {
            season = new Season();
        }

        return season;
    }

    private void StartSeason_OnSeasonStart(object sender, OnSeasonStartEventArgs e)
    {
        TruckFactory truckFactory = new TruckFactory();
        RaceFactory raceFactory = new RaceFactory();

        for (int i = 0; i < e.numOfPlayers; i++)
        {
            trucks.Add(truckFactory.MakePlayerTruck());
        }
        for (int i = 0; i < (4 - e.numOfPlayers); i++)
        {
            trucks.Add(truckFactory.MakeNPCTruck());
        }

        this.currentRace = raceFactory.MakeRace();

    }

    public void AddRace(Race r) 
    {
        raceHistory.Add(r);
    }

}

}
