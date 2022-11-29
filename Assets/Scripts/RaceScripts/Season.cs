using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RaceScripts {

// Class that represents a season in Super Off Road
// Implemented as a singleton because only one season can take place at a time
// Holds relevant information about the season
public class Season
{
    private static Season season = null;

    public const int maxNumOfRaces = 20;

    List<Race> raceHistory = new List<Race>(maxNumOfRaces);

    public Race currentRace = null;
    public List<GameObject> trucks = new List<GameObject>(4);
    public List<PersistentTruckData> trucks_data = new List<PersistentTruckData>();

    private Season() {}

    public static Season GetInstance() {
        if (season == null) {
            season = new Season();
        }

        return season;
    }

    public void StartSeason()
    {
        TruckFactory truckFactory = new TruckFactory();
        RaceFactory raceFactory = new RaceFactory();

        for (int i = 0; i < 1; i++)
        {
            season.trucks.Insert(i, truckFactory.MakePlayerTruck());
        }
        for (int i = 1; i < 4; i++)
        {
            season.trucks.Insert(i, truckFactory.MakeNPCTruck());
        }

        season.currentRace = raceFactory.MakeRace();
    }

    public void RaceEnds(GameObject truck, float time)
    {
        SceneManager.LoadScene("PostRaceScene");
        List<Score> scores = new List<Score>();

        if (truck.name == "Truck")
        {
            scores.Add(new Score(time, 1));
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(0f, 2));
        }
        else if (truck.name == "Truck (1)")
        {
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(time, 1));
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(0f, 2));
        }
        else if (truck.name == "Truck (2)")
        {
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(time, 1));
            scores.Add(new Score(0f, 2));
        }
        else if (truck.name == "Truck (3)")
        {
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(0f, 2));
            scores.Add(new Score(time, 1));
        }

        currentRace.RaceFinish(scores);

        for (int i = 0; i < 4; i++)
        {
            TruckController comp = season.trucks[i].GetComponent<TruckController>();
            season.trucks_data.Insert(i, new PersistentTruckData(comp.money, comp.nitroCount, comp.GetUpgrades(), comp.flagId));

            GameObject.Destroy(season.trucks[i]);
        }
        GameObject.Destroy(season.currentRace.track);

    }

    public void AddRace(Race r) 
    {
        season.raceHistory.Add(r);
    }

    public void StartNewRace()
    {
        TruckFactory truckFactory = new TruckFactory();
        RaceFactory raceFactory = new RaceFactory();

        for (int i = 0; i < 1; i++)
        {
            season.trucks.Insert(i, truckFactory.MakeExistingPlayerTruck(season.trucks_data[i]));
        }
        for (int i = 1; i < 4; i++)
        {
            season.trucks.Insert(i, truckFactory.MakeExistingNPCTruck(season.trucks_data[i]));
        }

        season.currentRace = raceFactory.MakeRace();

        SceneManager.LoadScene("SampleScene");
    }

}

public class PersistentTruckData
{
    public int money;
    public int nitroCount;
    public int[] upgrades;
    public int flagId;

    public PersistentTruckData(int m, int n, int[] u, int f)
    {
        this.money = m;
        this.nitroCount = n;
        this.upgrades = u;
        this.flagId = f;
    }
}

}
