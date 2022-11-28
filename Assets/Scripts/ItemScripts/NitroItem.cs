using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random=System.Random;

public class NitroItem : Item
{
    private int amount;
    
    // Start is called before the first frame update
    void Start()
    {
        Random rand = new Random();
        amount = rand.Next(1, 4); // 1, 2, 3 nitros
        if (amount == 1) {
            popupText = "1 nitro";
        } else {
            popupText = $"{amount} nitros";
        }
    }

    // Called when a truck runs over the item, collecting it
    public override void Collect(TruckController truck)
    {
        truck.nitroCount = truck.nitroCount + amount;
        Debug.Log(truck.nitroCount);
    }
}
