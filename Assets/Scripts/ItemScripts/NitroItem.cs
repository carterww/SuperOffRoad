using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroItem : Item
{
    // Called when a truck runs over the item, collecting it
    public override void Collect(TruckController truck)
    {
        truck.nitroCount++;
    }
}
