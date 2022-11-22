using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
        text.text = $"{truck.lapCount}\n{truck.nitroCount}";
    }
}
