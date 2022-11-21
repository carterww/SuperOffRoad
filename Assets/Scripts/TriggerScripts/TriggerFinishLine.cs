using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    void OnTriggerEnter2D(Collider2D other)
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            if (cont.c1 && cont.c2)
            {
                cont.incrementLapCount();
            }
            else
            {
                cont.c1 = false;
                cont.c2 = false;
            }
        }
    }
        
    
}
