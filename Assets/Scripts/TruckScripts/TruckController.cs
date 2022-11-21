using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// TODO: Flip downhill animation for going up hill through a function

// Attached to Truck object
public class TruckController : MonoBehaviour
{
    public const int MAX_LAP_COUNT = 5;
    
    // DELETE THIS -- only for testing, set in Unity inspector
    // Actual factory method should be used
    public bool setPlayer;

    public int lapCount = 1;
    public int nitroCount = 25;
    public bool c1, c2 = false;  // checkpoints that get set to true with collision on triggers

    Animator animator;
    bool upHill = false;
    Rigidbody2D rigidBody2D;

    TruckControllerImp implementation;

    // Physics variables, will need fine tuning
    /*Vector2 facing = new Vector2(-1, 0);
    float ySquash = 1.0f;
    Vector2 velocity = new Vector2();
    float frictionCoeff = 2.5f;
    float maxSpeed = 3f;
    float maxAccel = 8f;
    //float slipSpeed = 1.8f;
    */
    Vector2 facing = new Vector2(-1, 0);
    Vector2 velocity = new Vector2();
    // modular friction based on velocity vector components, gives smoother turn transition than orbit-based steering
    float frictionCoeffForward = 2f; // front-back friction, aka if you pushed a car forwards
    float frictionCoeffLateral = 5f; // side-to-side friction, aka if you pushed a car from the side
    float maxAccel = 8f;
    float maxTurnSpeed = 4f; // radians per second
    float wallBounce = 0.5f; // amount to push the truck off the wall, proportional to velocity
    float truckBounce = 1.0f; // amount to bump trucks away from each other, proportional to velocity

    /* 
    TODO: maximum speed is constrained by maxAccel and frictionCoeffForward from the 
    differential equation: dv/dt = a_max - f*v
    Need to determine best method for upgrading speed separately from acceleration
    */ 

    // Called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("X", -1.0f); animator.SetFloat("Y", 0.0f);
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Hard coded variable for testing
        if (setPlayer) {
            implementation = new PlayerTruckController();
        } else {
            implementation = new NPCTruckController(this);
        }
        implementation.Start();
    }

    // Called once per rendering frame -- for visual changes
    void Update()
    {
        implementation.Update();
        // Since upHill animtion is flippedX of downhill animation, invert x facing direction
        animator.SetFloat("X", upHill ? -facing.x : facing.x);
        animator.SetFloat("Y", facing.y);
    }

    // Called once per physics frame -- independent from FPS
    void FixedUpdate()
    {
        // added this for new transform
        Vector2 position = rigidBody2D.position;

        float dt = Time.fixedDeltaTime;
        (float accel, float turn) control = implementation.Control();
        /*
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
            float R = 0.8f;
            float orbit = (velocity.magnitude * velocity.magnitude) / R;
            turnAccel = Vector2.Perpendicular(facing) * Mathf.Sign(control.turn) * orbit;
        }
        // Second pass
        velocity = velocity + turnAccel * dt;
        // Position update
        rigidBody2D.MovePosition(new Vector2(velocity.x * dt, velocity.y * dt) + position);
        //transform.Translate(velocity.x * dt, velocity.y * dt, 0);
        
        // Updating new facing direction
        if (velocity.magnitude > 0.01f) // prevents facing from becoming a zero vector
        {
            facing = velocity.normalized;
        }
        */

        // Update facing position from steering
        float dtheta = control.turn * maxTurnSpeed * dt;
        Vector2 turnVec = Mathf.Tan(dtheta) * Vector2.Perpendicular(facing);
        facing = (facing + turnVec).normalized;
        // Acceleration and friction calculation
        Vector2 engineAccel = facing * control.accel * maxAccel;
        Vector2 prevVelForward = Vector2.Dot(velocity, facing) * facing;
        Vector2 frictionForward = prevVelForward * -frictionCoeffForward;
        Vector2 frictionLateral = (velocity - prevVelForward) * -frictionCoeffLateral;
        // Euler-Cromer
        velocity = velocity + (engineAccel + frictionForward + frictionLateral) * dt;
        rigidBody2D.MovePosition(position + velocity * dt);
    }

    // Called when the truck enters a collision area
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider) {
            if (col.collider is EdgeCollider2D) {
                // truck has hit a wall, bounce off normal!
                Vector2 normal = col.GetContact(0).normal;
                Vector2 comp = Vector2.Dot(normal, velocity) * normal; // component of velocity vector that is parallel to normal
                velocity = velocity - (comp * (1f + wallBounce));
            }
            if (col.collider is BoxCollider2D) {
                // truck has hit another truck, bounce off direction!
                Vector2 bounceDirection = (rigidBody2D.position - col.rigidbody.position).normalized;
                Vector2 comp = Vector2.Dot(bounceDirection, velocity) * bounceDirection; // component of velocity vector that is parallel to bounceDirection
                velocity = velocity - (comp * (1f + truckBounce));
            }
        }
    }

    public void SetController(TruckControllerImp c) {
        this.implementation = c;
    }

    // called by triggerDownHill
    public void SwitchDownHill(bool state)
    {
        animator.SetBool("DownHill", state);
    }

    // Called by triggerUpHill
    public void SwitchUpHill(bool state)
    {
        animator.SetBool("DownHill", state);

        SpriteRenderer s = GetComponent<SpriteRenderer>();

        if (state == true)
        {
            s.flipX = true;
            upHill = true;
        }
        else
        {
            s.flipX = false;
            upHill = false;
        }
    }

    // Casts rays out to collider objects in the forward facing hemisphere of the truck
    public float[] ForwardRaycast()
    {
        // prepare directions
        Vector2 perp = Vector2.Perpendicular(facing);
        Vector2[] dirs = { perp, (facing + perp).normalized, facing, (facing - perp).normalized, -perp };
        // raycast and return distances
        float[] dists = new float[5];
        Vector2 pos = rigidBody2D.position;
        for (int i = 0; i < 5; i++) {
            RaycastHit2D hit = Physics2D.Raycast(pos, dirs[i], 20.0f);
            if (hit.collider != null) {
                dists[i] = (hit.point - pos).magnitude;
            } else {
                dists[i] = 20.0f;
            }
        }
        return dists;
    }

    public void incrementLapCount()
    {
        this.lapCount++;
        c1 = c2 = false;

        if (lapCount >= MAX_LAP_COUNT)
        {
            // Add logic for finishing race
            Debug.Log("Race should be finished");
        }
    }

    public void incrementNitroCount()
    {
        nitroCount += 1;
    }
}