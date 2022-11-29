using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RaceScripts;

public class TruckFactory
{
    // reference to Truck prefab in prefabs/Truck
    [SerializeField]
    public GameObject truckPrefab;
    public static int index;

    private Vector3[] positions = {new Vector3(-.35f, -3.23f, 0f), new Vector3(-.52f, -3.66f, 0f), new Vector3(.35f, -3.23f, 0f), new Vector3(.2f, -3.66f, 0f)};

    public TruckFactory() {
        index = 0;
        truckPrefab = (GameObject)Resources.Load("RealTruck", typeof(GameObject));
        if (truckPrefab == null)
        {
            Debug.Log("Null");
        }
        else {
            Debug.Log("Grabbed Prefab");}
    }

    private Vector3 getPos()
    {
        return positions[index++];
    }

    public GameObject MakeExistingPlayerTruck(PersistentTruckData data)
    {
        GameObject newTruck = MakePlayerTruck();
        return LoadPersistentTruckData(newTruck, data);
    }

    public GameObject MakeExistingNPCTruck(PersistentTruckData data)
    {
        GameObject newTruck = MakeNPCTruck();
        return LoadPersistentTruckData(newTruck, data);
    }

    private GameObject LoadPersistentTruckData(GameObject truck, PersistentTruckData data)
    {
        TruckController controller = truck.GetComponent<TruckController>();

        controller.money = data.money;
        controller.nitroCount = data.nitroCount;
        controller.SetUpgrades(data.upgrades);
        controller.flagId = data.flagId;

        //Debug.Log(truck.name);
        //Debug.Log(controller.money);
        //Debug.Log(controller.nitroCount);
        //Debug.Log($"{controller.upgrades[0]}, {controller.upgrades[1]}, {controller.upgrades[2]}, {controller.upgrades[3]}, {controller.upgrades[4]}");

        return truck;
    }

    public GameObject MakePlayerTruck() {

        // creates new truck gameobject, uses truck in prefabs/Truck as prototype
        GameObject newTruck = GameObject.Instantiate(truckPrefab, getPos(), new Quaternion(0, 0, 0, 0)) as GameObject;
        newTruck.name = "Truck";
        Debug.Log("Made Truck");
        TruckController controller = newTruck.GetComponent<TruckController>();

        // set implementation of truck controls to a player
        controller.SetController(new PlayerTruckController());

        // TODO implement to where the truck gets moved to correct starting position and color
        return newTruck;
    }

    public GameObject MakeNPCTruck() {

        // creates new truck gameobject, uses truck in prefabs/Truck as prototype
        GameObject newTruck = GameObject.Instantiate(truckPrefab, getPos(), new Quaternion(0, 0, 0, 0)) as GameObject;
        newTruck.name = "Truck (" + (index - 1).ToString() + ")";
        TruckController controller = newTruck.GetComponent<TruckController>();
        SpriteRenderer renderer = newTruck.GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.4f, 0.4f, 0.4f);

        // set implementation of truck controls to an NPC
        controller.SetController(new NPCTruckController(controller));

        // TODO implement to where the truck gets moved to correct starting position and color
        return newTruck;
    }

}
