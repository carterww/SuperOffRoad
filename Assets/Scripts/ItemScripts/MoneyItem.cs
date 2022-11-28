using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyItem : Item
{
    private int amount;
    
    // Start is called before the first frame update
    void Start()
    {
        amount = 25000; // TODO: randomize?
    }

    // Called when a truck runs over the item, collecting it
    public override void Collect(TruckController truck)
    {
        Debug.Log(truck.money.ToString() + " --> " + (truck.money + amount).ToString());
        truck.money = truck.money + amount;
    }
}
