using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random=System.Random;

public class ItemFactory : MonoBehaviour
{
    public Vector2[] locations;
    private bool canPlace;
    private float t;
    private Random rand;

    public GameObject moneyItemPrefab;
    public GameObject nitroItemPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        canPlace = locations.Length > 0;
        t = 0.0f;
        rand = new Random();
        moneyItemPrefab = (GameObject)Resources.Load("MoneyItem", typeof(GameObject));
        nitroItemPrefab = (GameObject)Resources.Load("NitroItem", typeof(GameObject));
        Debug.Log(nitroItemPrefab);
    }

    // Update is called once per frame
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

    public void onCollected(Item item)
    {
        if (item != null && !canPlace) {        
            t = 0.0f;
            canPlace = true;
        }
    }
}
