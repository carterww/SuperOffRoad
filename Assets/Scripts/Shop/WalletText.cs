using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RaceScripts;

public class WalletText : MonoBehaviour
{
    Text textCmp;

    // Start is called before the first frame update
    void Start()
    {
        textCmp = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textCmp.text = $"${Season.GetInstance().trucks_data[0].money}";
    }
}
