using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // Called when a truck runs over the item, collecting it
    public abstract void Collect(TruckController truck);

    void OnTriggerEnter2D(Collider2D col)
    {
        TruckController truck = col.gameObject.GetComponent<TruckController>();
        ItemFactory fac = GameObject.Find("ItemSpawner").GetComponent<ItemFactory>();
        if (truck != null && fac != null) {
            Collect(truck);
            fac.onCollected(this);
            Destroy(gameObject); // removes the item when done
        }
    }
}
