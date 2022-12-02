using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random=System.Random;

// Item Factory is responsible for spawning the nitro and money item pickups
// It randomly chooses between the two, and spawns it in one of
// many pre-determined locations
// Items spawn 3 seconds after the race begins and the last item pickup
public class ItemFactory : MonoBehaviour
{
    public Vector2[] locations;
    private bool canPlace;
    private float t;
    private Random rand;

    // prefabs for items
    public GameObject moneyItemPrefab;
    public GameObject nitroItemPrefab;
    
    void Start()
    {
        canPlace = locations.Length > 0;
        t = 0.0f;
        rand = new Random();
        moneyItemPrefab = (GameObject)Resources.Load("MoneyItem", typeof(GameObject));
        nitroItemPrefab = (GameObject)Resources.Load("NitroItem", typeof(GameObject));
        Debug.Log(nitroItemPrefab);
    }

    void Update()
    {
        if (canPlace) {
            t = t + Time.deltaTime;
            if (t > 3.0) {
                CreateItem();
            }
        }
    }

    private void CreateItem()
    {
        Debug.Log("creating item");
        int j = rand.Next(0, locations.Length);
        int p = rand.Next(0, 2);
        if (p == 0) {
            CreateNitroItem(locations[j]);
        } else {
            CreateMoneyItem(locations[j]);
        }
        canPlace = false;
    }

    // Creates a Money item at the location
    private void CreateMoneyItem(Vector2 loc)
    {
        GameObject it = GameObject.Instantiate(moneyItemPrefab);
        it.transform.position = loc;
    }

    // Creates a Nitro item at the location
    private void CreateNitroItem(Vector2 loc)
    {
        GameObject it = GameObject.Instantiate(nitroItemPrefab);
        it.transform.position = loc;
    }

    // Once collected, resets variables that dictate whether item can spawn
    public void onCollected(Item item)
    {
        if (item != null && !canPlace) {        
            t = 0.0f;
            canPlace = true;
        }
    }
}
