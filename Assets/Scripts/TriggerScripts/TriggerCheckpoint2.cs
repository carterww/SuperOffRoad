using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckpoint2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    // Called when truck passes through second checkpoint
    void OnTriggerEnter2D(Collider2D other)
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            cont.c2 = true;
        }
    }
}
