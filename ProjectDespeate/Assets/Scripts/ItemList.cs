using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList
{
    public string ItemName;
    public float ItemWorth;

    public ItemList(string newName, float newWorth)
    {
        ItemName = newName;
        ItemWorth = newWorth;
    }
}
