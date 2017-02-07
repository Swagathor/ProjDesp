using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList
{
    public string ItemName;
    public float ItemWorth;
    public string ItemDiscription;

    public ItemList(string newName, float newWorth, string newDisc)
    {
        ItemName = newName;
        ItemWorth = newWorth;
        ItemDiscription = newDisc;
    }
}
