using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    [SerializeField]
    private Item currentItem;

    [SerializeField]
    public Image customCursor;

    public int itemCount = 0;

    [SerializeField]
    private ItemSlot[] itemSlot;

    [SerializeField]
    private List<Item> items = new List<Item>();

    [SerializeField]
    private Image[] itemImage;

    [SerializeField]
    private ItemSlot[] craftingSlots;

    private void Awake()
    {
        UpdateItems();
        UpdateItemSprites();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (currentItem != null)
            {
                customCursor.gameObject.SetActive(false);

                ItemSlot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(ItemSlot slot in craftingSlots)
                {
                    float distance = Vector2.Distance(Input.mousePosition, slot.transform.position);
                    
                    if(distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        nearestSlot = slot;
                    }
                    nearestSlot.item = currentItem;
                }
                nearestSlot.CreateItem(currentItem);
                currentItem = null;
            }
        }
    }

    public void OnMouseDownItem(ItemSlot itemSlot)
    {
        if (currentItem == null)
        {
            currentItem = itemSlot.item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.itemIcon;
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

    void UpdateItemSprites()
    {
        for (int i = 0; i < items.Count; i++)
        {
            for (int j = i; j < items.Count; j++)
            {
                itemImage[j].gameObject.SetActive(true);
                itemImage[j].sprite = items[i].itemIcon;
            }
        }
    }
}