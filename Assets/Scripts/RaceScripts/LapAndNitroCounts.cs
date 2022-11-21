using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapAndNitroCounts : MonoBehaviour
{
    Text text;
    TruckController[] trucks = new TruckController[4];

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        trucks[0] = GameObject.Find("Truck").GetComponent<TruckController>();
        trucks[1] = GameObject.Find("Truck (1)").GetComponent<TruckController>();
        trucks[2] = GameObject.Find("Truck (2)").GetComponent<TruckController>();
        trucks[3] = GameObject.Find("Truck (3)").GetComponent<TruckController>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{trucks[0].lapCount}  {trucks[1].lapCount}  {trucks[2].lapCount}  {trucks[3].lapCount}\n{trucks[0].nitroCount} {trucks[1].nitroCount} {trucks[2].nitroCount} {trucks[3].nitroCount}";
    }
}
