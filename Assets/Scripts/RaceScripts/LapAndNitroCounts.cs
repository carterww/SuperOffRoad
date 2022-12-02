using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Component that displays the lap and nitro count on the scoreboard
public class LapAndNitroCounts : MonoBehaviour
{
    Text text;
    TruckController truck;
    public string TruckName;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        truck = GameObject.Find(TruckName).GetComponent<TruckController>();
    }

    // Updates the scoreboard with new counts every frame
    // Would be more effecient to set an event that causes counts
    // to change on scoreboard
    void Update()
    {
        text.text = $"{truck.lapCount}\n{truck.nitroCount}";
    }
}
