using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    public Sprite itemIcon;
    public string itemDescription = "ITEM WAS USED!";
    public bool isConsumable = false;
    public void UseItem()
    {
        Debug.Log("Used " + name + ". " + itemDescription);
    }
}
