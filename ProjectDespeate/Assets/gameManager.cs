using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    [HideInInspector]
    public float m_score;

    public static gameManager instance;
    List<ItemList> Inventory = new List<ItemList>(); 
    // Use this for initialization
    void Awake ()
    {
        instance = this; 
    }
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void AddtoList(string itemName, float itemWorth)
    {
        m_score = itemWorth + m_score;
        Inventory.Add(new ItemList(itemName, itemWorth));
    }
}
