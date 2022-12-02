using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles changing animation to downhill animation
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

    // switch blend tree bool to true for downhill
    void OnTriggerStay2D(Collider2D other) 
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            cont.SwitchDownHill(true);
        }
    }

    // switch blend tree bool to false
    // switches back to default driving
    void OnTriggerExit2D(Collider2D other)
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            cont.SwitchDownHill(false);
        }
    }
}
