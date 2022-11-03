using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDownHill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            cont.SwitchDownHill(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            cont.SwitchDownHill(false);
        }
    }
}
