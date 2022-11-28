using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GoToSceneButton : MonoBehaviour{

    public GameObject submitButton;
    public string sceneToLoad;

    void Start(){
        Button btn = submitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        SceneManager.LoadScene(sceneToLoad);
    }
}