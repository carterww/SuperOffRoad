using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public GameObject popupPrefab;
    protected string popupText;
    
    // Start is called before the first frame update
    void Start()
    {
        //popupPrefab = (GameObject)Resources.Load("ItemTextPopup", typeof(GameObject));
    }

    // Called when a truck runs over the item, collecting it
    public abstract void Collect(TruckController truck);

    void OnTriggerEnter2D(Collider2D col)
    {
        TruckController truck = col.gameObject.GetComponent<TruckController>();
        ItemFactory fac = GameObject.Find("ItemSpawner").GetComponent<ItemFactory>();
        if (truck != null && fac != null) {
            Collect(truck);
            fac.onCollected(this);
            GameObject popup = GameObject.Instantiate(popupPrefab);
            popup.transform.position = transform.position;
            popup.GetComponent<ItemTextPopup>().SetText(popupText);
            Destroy(gameObject); // removes the item when done
        }
    }
}
