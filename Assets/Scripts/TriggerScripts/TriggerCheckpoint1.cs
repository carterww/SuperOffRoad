using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckpoint1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    // Called when truck reaches the first checkpoint
    void OnTriggerEnter2D(Collider2D other)
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            // reset checkpoints if truck is going backwards
            if (cont.c2)
            {
                cont.c1 = false;
                cont.c2 = false;
            }
            else
            {
                cont.c1 = true;
            }
        }
    }
}
