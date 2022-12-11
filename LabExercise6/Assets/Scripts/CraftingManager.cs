using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField]
    private Item currentItem;

    [SerializeField]
    private ItemSlot[] itemSlot;

    [SerializeField]
    private Item[] items;

    public int itemCount = 0;

    private void Awake()
    {
        UpdateItems();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (currentItem == items[i])
                {
                    currentItem = null;
                    Debug.Log("ITEM RELEASED");
                }
            }
        }
    }

    public void OnMouseDragItem()
    {
        if (currentItem == null)
        {
            for (int i = 0; i < items.Length; i++)
            {
                currentItem = items[i];
                currentItem.itemIcon = items[i].itemIcon;
                Debug.Log("NEW ITEM");
            }
        }
    }
    
    void UpdateItems()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            int temp = itemCount;
            if (itemSlot[i].IsSlotEmpty() == false)
            {
                itemCount += 1;
                items = new Item[itemCount];
                items[temp] = itemSlot[i].SetItem();
            }
        }
    }
}

