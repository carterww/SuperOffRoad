using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TruckController : MonoBehaviour
{
    // Need to implement factory method here to choose
    // Hard coded variable for testing
    TruckControllerImp implementation = new PlayerTruckController();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
