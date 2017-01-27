using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemPickup : MonoBehaviour {


    BoxCollider Collider;

    [TextArea(1, 10)]
    public string itemName = "item";
    public float worth;

    gameManager Manager;
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            //do stuff
            Debug.Log("Player picked up Item");

            Manager.AddtoList(itemName, worth);
            
            DestroyObject(gameObject, 0.1f);
        }
    }
}
