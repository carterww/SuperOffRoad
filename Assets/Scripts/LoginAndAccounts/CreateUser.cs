using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using RaceScripts;

public class CreateUser : MonoBehaviour{

    public GameObject usernameBox;
    public GameObject passwordBox;

    public GameObject submitButton;

    void Start(){

        Button btn = submitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    private bool is_alphanumeric(string val) {

        for (int c = 0; c < val.Length; c++) if (!char.IsLetterOrDigit(val[c])) return false;
        return true;

    }

    void TaskOnClick(){

        string username = usernameBox.GetComponent<TMP_InputField>().text;
        string password = passwordBox.GetComponent<TMP_InputField>().text;

        if (!is_alphanumeric(username) || !is_alphanumeric(password)) {
            Debug.Log("Username and password must be alphanumeric.");
            return;
        }

        if (username.Length > 16) {
            Debug.Log("Username has a maximum length of 16 characters.");
            return;
        }

        DatabaseSingleton db = GameObject.Find("Database").GetComponent<DatabaseSingleton>();

        if (!db.CheckUsername(username)) {
            Debug.Log("Username " + username + " already exists.");
            return;
        }

        db.CreateUser(username, password);

        SceneManager.LoadScene("LoginScene");
    }
}