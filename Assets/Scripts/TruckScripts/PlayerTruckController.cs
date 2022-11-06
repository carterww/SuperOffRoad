using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TruckController implementation for a player truck
public class PlayerTruckController : TruckControllerImp
{
    bool inputThrottle;
    bool inputKeyLeft;
    bool inputKeyRight;
    float inputDirection;

    public PlayerTruckController() {}
    
    // Start is called before the first frame update
    public override void Start()
    {
        inputThrottle = false;
        inputKeyLeft = false;
        inputKeyRight = false;
        inputDirection = 0.0f;
    }

    // Update is called once per frame
    public override void Update()
    {
        // TODO Could an else statement be used for each GetKeyUp since it is binary?
        // Unfortunately not, GetKeyDown and GetKeyUp are only true on frames where the keystate has just changed
        if (Input.GetKeyDown(KeyCode.W)) inputThrottle = true;
        if (Input.GetKeyUp(KeyCode.W)) inputThrottle = false;
        if (Input.GetKeyDown(KeyCode.A)) inputKeyLeft = true;
        if (Input.GetKeyUp(KeyCode.A)) inputKeyLeft = false;
        if (Input.GetKeyDown(KeyCode.D)) inputKeyRight = true;
        if (Input.GetKeyUp(KeyCode.D)) inputKeyRight = false;
        inputDirection = 0.0f;
        if (inputKeyLeft) inputDirection += 1;
        if (inputKeyRight) inputDirection -= 1;
    }

    // Determines the acceleration and steering direction for the truck
    public override (float, float) Control()
    {
        return new (inputThrottle ? 1.0f : 0.0f, inputDirection);
    }
}
