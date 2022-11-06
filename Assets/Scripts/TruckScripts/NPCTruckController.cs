using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TruckController implementation for a non-player truck
public class NPCTruckController : TruckControllerImp
{
    float biasForward;
    float biasQuarter;
    float biasLateral;
    const float variance = 0.1f;
    
    public NPCTruckController(TruckController truck)
    {
        this.truck = truck;
    }
    
    // Start is called before the first frame update
    public override void Start()
    {
        biasForward = Random.Range(1f - variance, 1f + variance);
        biasQuarter = Random.Range(1f - variance, 1f + variance);
        biasLateral = Random.Range(1f - variance, 1f + variance);
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    // Determines the acceleration and steering direction for the truck
    public override (float, float) Control()
    {
        // Perform raycasts
        float[] dists = truck.ForwardRaycast();
        Vector2 sum = (new Vector2(-1, 0) * dists[0] * biasLateral) +
                      (new Vector2(-0.707f, 0.707f) * dists[1] * biasQuarter) +
                      (new Vector2(0, 1) * dists[2] * biasForward) +
                      (new Vector2(0.707f, 0.707f) * dists[3] * biasQuarter) +
                      (new Vector2(1, 0) * dists[4] * biasLateral);
        return (1f, -sum.normalized.x);
    }
}
