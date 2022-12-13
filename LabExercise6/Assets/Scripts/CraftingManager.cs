using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    [SerializeField]
    private Item currentItem;

    [SerializeField]
    private ItemSlot[] itemSlot;

    [SerializeField]
    private List<Item> items = new List<Item>();

    [SerializeField]
    public Image customCursor;

    public int itemCount = 0;

    private void Awake()
    {
        UpdateItems();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (currentItem == items[i])
                {
                    currentItem = null;
                    customCursor.gameObject.SetActive(false);
                    Debug.Log("ITEM RELEASED");
                }
            }
        }
    }

    public void OnMouseDown()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (currentItem == null)
            {
                customCursor.gameObject.SetActive(true);
                currentItem = itemSlot[i].SetItem();
                currentItem.itemIcon = items[i].itemIcon;
                customCursor.sprite = currentItem.itemIcon;
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
                items.Add(itemSlot[i].SetItem());
                items[temp] = itemSlot[i].SetItem();
            }
        }
    }
}

