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

    [Header("Crafting")]
    [SerializeField]
    private Image[] itemImage;

    [SerializeField]
    private ItemSlot[] craftingSlots;

    [Header("Recipe Items")]
    [SerializeField]
    private List<Item> recipeItems = new List<Item>();

    [SerializeField]
    private string[] recipes;

    [SerializeField]
    private Item[] recipeResultItems;

    [SerializeField]
    private ItemSlot resultSlot;

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
                }
                nearestSlot.item = currentItem;
                UpdateRecipeItems(currentItem);
                nearestSlot.CreateItem(currentItem);
                currentItem = null;

                CheckForCompletedRecipe();
            }
        }
    }

    private void CheckForCompletedRecipe()
    {
        resultSlot.item = null;

        string currentRecipeString = "";


        foreach(Item item in recipeResultItems)
        {
            if(item != null)
            {
                currentRecipeString += item.name;
            }
            else
            {
                currentRecipeString += "Null";
            }
        }

        for(int i = 0; i < recipes.Length; i++)
        {
            if(recipes[i] == currentRecipeString)
            {
                resultSlot.item = recipeResultItems[i];
                resultSlot.CreateItem(recipeResultItems[i]);
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

    void UpdateRecipeItems(Item item)
    {
        foreach(ItemSlot slot in craftingSlots)
        {
            if (craftingSlots == null)
            {
                recipeItems.Add(item);
                recipeItems[itemCount] = item;
                itemCount += 1;
            }
        }
    }
}