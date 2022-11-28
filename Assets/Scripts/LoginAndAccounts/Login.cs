using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using RaceScripts;

public class Login : MonoBehaviour{

    public GameObject usernameBox;
    public GameObject passwordBox;

    public GameObject submitButton;

    void Start(){
        Button btn = submitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        Debug.Log("Checking username and password");
        //if(usernameBox.GetComponent<TMP_InputField>().text.Equals("username") && passwordBox.GetComponent<TMP_InputField>().text.Equals("password")){//temporary ofc, will need to check the database instead
            Debug.Log("Username and password accepted for user " + usernameBox.GetComponent<TMP_InputField>().text);

            Season s = Season.GetInstance();
            SceneManager.LoadScene("SampleScene");
            s.StartSeason();
            //s.InstantiateGameObjects();
        //}else{
            Debug.Log("Password does not match with username " + usernameBox.GetComponent<TMP_InputField>().text);
        //}
    }
}