using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUpHill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // switches animation to uphill by setting bool in blend tree to true
    void OnTriggerStay2D(Collider2D other) 
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            cont.SwitchUpHill(true);
        }
    }

    // switches animation to default by switching bool in blend tree to false
    void OnTriggerExit2D(Collider2D other)
    {
        TruckController cont = other.GetComponent<TruckController>();

        if (cont != null)
        {
            cont.SwitchUpHill(false);
        }
    }
}
