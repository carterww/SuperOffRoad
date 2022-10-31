using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to Truck object
public class TruckController : MonoBehaviour
{
    // Need to implement factory method here to choose
    // Hard coded variable for testing
    TruckControllerImp implementation = new PlayerTruckController();

    // Physics variables, will need fine tuning
    Vector2 facing = new Vector2(1, 0);
    Vector2 velocity = new Vector2();
    float frictionCoeff = 2.5f;
    float maxSpeed = 3f;
    float maxAccel = 12f;
    //float slipSpeed = 1.8f;

    // Start is called before the first frame update
    void Start()
    {
        implementation.Start();
    }

    // Update is called once per frame
    void Update()
    {
        implementation.Update();
    }

    // Called once per physics frame -- independent from FPS
    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        (float accel, float turn) control = implementation.Control();

        // First pass, before steering
        Vector2 engineAccel = facing * control.accel * maxAccel;
        Vector2 friction = velocity * -frictionCoeff;
        velocity = velocity + (engineAccel + friction) * dt;
        // Speed clamping
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        // Steering
        Vector2 turnAccel = new Vector2();
        if (!Mathf.Approximately(control.turn, 0.0f))
        {
            // using orbit mechanics, a = v^2 / R
            // TODO: R needs to be a function of the absolute value of control.turn, unless analog steering is not implemented
            // R should get bigger as control.turn gets closer to zero, and smaller when control.turn approaches 1 or -1
            float R = 1;
            float orbit = (velocity.magnitude * velocity.magnitude) / R;
            turnAccel = Vector2.Perpendicular(facing) * Mathf.Sign(control.turn) * orbit;
        }
        // Second pass
        velocity = velocity + turnAccel * dt;
        // Position update
        transform.Translate(velocity.x * dt, velocity.y * dt, 0);
        
        // Updating new facing direction
        if (!Mathf.Approximately(velocity.magnitude, 0.0f))
        {
            facing = velocity.normalized;
        }
    }
}