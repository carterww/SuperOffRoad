using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TruckControllerImp
{
    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();
    

    // Determines the acceleration and steering direction for the truck
    public abstract (float, float) Control();
}