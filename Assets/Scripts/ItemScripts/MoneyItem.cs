using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random=System.Random;

public class MoneyItem : Item
{
    private int amount;
    
    // Start is called before the first frame update
    void Start()
    {
        Random rand = new Random();
        amount = 10000 * rand.Next(1, 4); // 10000, 20000, 30000
        popupText = $"${amount}";
    }

    // Called when a truck runs over the item, collecting it
    public override void Collect(TruckController truck)
    {
        Debug.Log(truck.money.ToString() + " --> " + (truck.money + amount).ToString());
        truck.money = truck.money + amount;
        Debug.Log(truck.money);
    }
}
