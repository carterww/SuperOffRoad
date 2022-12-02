using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps GameObject from automatically being destroyed on scene transition
public class Saveme : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
