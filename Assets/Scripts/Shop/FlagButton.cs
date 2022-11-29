using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RaceScripts;

public class FlagButton : MonoBehaviour
{
    public int flagId;
    Season season;
    
    // Start is called before the first frame update
    void Start()
    {
        season = Season.GetInstance();
        
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {   
        Debug.Log($"Flag chosen: {flagId}");
        Season s = Season.GetInstance();
        SceneManager.LoadScene("SampleScene");
        s.StartSeason();
        s.trucks[0].GetComponent<TruckController>().flagId = this.flagId;
    }
}
