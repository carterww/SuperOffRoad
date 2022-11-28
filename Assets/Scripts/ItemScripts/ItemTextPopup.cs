using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTextPopup : MonoBehaviour
{
    float t = 0.0f;

    // Update is called once per frame
    void Update()
    {
        t = t + Time.deltaTime;
        if (t > 2) {
            Destroy(gameObject);
        }
    }

    // Sets the text of the text component
    public void SetText(string text)
    {
        Text textCmp = gameObject.GetComponentInChildren(typeof(Text)) as Text;
        textCmp.text = text;
    }
}
