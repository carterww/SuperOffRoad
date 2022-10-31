using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TruckController implementation for a non-player truck
public class NPCTruckController : TruckControllerImp
{
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    // Determines the acceleration and steering direction for the truck
    public override (float, float) Control()
    {
        return (0, 0);
    }
}
