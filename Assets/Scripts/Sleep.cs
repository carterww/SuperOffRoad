using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sleeps for sleepTime seconds and transitions to new scene after
public class Sleep : MonoBehaviour
{

    public float sleepTime;
    public string sceneToLoad;
    private float timerTime;
    // Start is called before the first frame update
    void Start()
    {
        timerTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timerTime += Time.deltaTime;
        if (timerTime >= sleepTime)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
