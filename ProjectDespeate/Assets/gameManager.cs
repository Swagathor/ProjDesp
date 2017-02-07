using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    [HideInInspector]
    public float m_score;

    public static gameManager instance;
    List<ItemList> Inventory = new List<ItemList>();
     

    


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
    public void AddtoList(string itemName, float itemWorth, string ItemDescription)
    {
        m_score = itemWorth + m_score;
        Inventory.Add(new ItemList(itemName, itemWorth, ItemDescription));
    }
}
