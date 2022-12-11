using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Item item = null;
    [SerializeField]
    private int itemCount = 0;
    public int Count
    {
        get { return itemCount; }
        set
        {
            itemCount = value;
            UpdateItemGraphic();
        }
    }
    
    [SerializeField]
    Image itemIcon;
    
    [SerializeField]
    TextMeshProUGUI itemCountText;

    void Start()
    {
        UpdateItemGraphic();       
    }

    void UpdateItemGraphic()
    {
        if(itemCount < 1)
        {
            item = null;
            itemIcon.gameObject.SetActive(false);
        }
        else
        {
            itemIcon.sprite = item.itemIcon;
            itemIcon.gameObject.SetActive(true);
            itemCountText.text = itemCount.ToString();
        }
    }

    public void UseItemInSlot()
    {
        if(CanUseItem(item))
        {
            item.UseItem();
            
            if(item.isConsumable)
            {
                Count--;
            }
        }
    }

    private bool CanUseItem(Item item)
    {
        if(item == null)
        {
            return false;
        }
        
        if (itemCount < 1)
        {
            return false;
        }

        return true;
    }
    
    public bool IsSlotEmpty()
    {
        if(item == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Item SetItem()
    {
        return item;
    }
}
