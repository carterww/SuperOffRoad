using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckFactory
{
    // reference to Truck prefab in prefabs/Truck
    GameObject truckPrefab;

    public TruckFactory() {
        truckPrefab = (GameObject)Resources.Load("prefabs/Truck", typeof(GameObject));
    }

    public GameObject MakePlayerTruck() {

        // creates new truck gameobject, uses truck in prefabs/Truck as prototype
        GameObject newTruck = GameObject.Instantiate(truckPrefab);
        TruckController controller = newTruck.GetComponent<TruckController>();

        // set implementation of truck controls to a player
        controller.SetController(new PlayerTruckController());

        // TODO implement to where the truck gets moved to correct starting position and color
        return newTruck;
    }

    public GameObject MakeNPCTruck() {

        // creates new truck gameobject, uses truck in prefabs/Truck as prototype
        GameObject newTruck = GameObject.Instantiate(truckPrefab);
        TruckController controller = newTruck.GetComponent<TruckController>();

        // set implementation of truck controls to an NPC
        controller.SetController(new NPCTruckController());

        // TODO implement to where the truck gets moved to correct starting position and color
        return newTruck;
    }

}
