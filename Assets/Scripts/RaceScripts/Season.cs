using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaceScripts {

// Class that represents a season in Super Off Road
// Implemented as a singleton because only one season can take place at a time
// Holds relevant information about the season
public class Season : MonoBehaviour
{
    private Season season = null;

    public const int maxNumOfRaces = 20;
    int numOfRaces = 0;

    List<Race> raceHistory = new List<Race>(maxNumOfRaces);
    List<GameObject> trucks = new List<GameObject>(4);

    private Season() {}

    public Season GetInstance() {
        if (season == null) {
            this.season = new Season();
        }

        return this.season;
    }

    // pass in list of trucks created before season start
    // need to implement a factory method for creating Truck gameobjects
    public void InitializeSeason(List<GameObject> trucks) {
        this.trucks = trucks;

        // create the first race object
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}
