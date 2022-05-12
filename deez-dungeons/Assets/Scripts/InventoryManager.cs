using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;


    
    private void Awake()
    {
        Instance = this;
    }

    public void Pickup(Item item)
    {

            item.amount++;
            Item result = Items.Find(x => x == item);
            if (result == null)
            {
                Items.Add(item);
            }
            Items.Add(item);
    }

    public void Add(Item item)             //adding code come back to debug
    {
         //testing for stackables
        
        //testing for stackables 
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);          
    }

    public void ClearItemsOnClose()   
    {
        foreach (Transform item in ItemContent)         //changed transform to gameobject to try and debug
        {
            Destroy(item.gameObject);
        }
    }
    public void ListItems()
    {
        //clean content before open

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();            
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            var equipButton = obj.transform.Find("EquipButton").GetComponent<Button>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            TextMeshProUGUI uiText = obj.transform.Find("amountText").GetComponent<TextMeshProUGUI>();     //added for ammount text on stackables, check below for bugs
            if(item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }

            if (EnableRemove.isOn)
                removeButton.gameObject.SetActive(true);
            if(item.itemEquipped == true)
            {
                equipButton.gameObject.SetActive(true);
            }
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach(Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        //if (InventoryItem.GetComponent<InventoryItemController>().itemEquipped == true)
        //{
            //Debug.Log(InventoryItem.GetComponent<InventoryItemController>().itemEquipped);
            //InventoryItem.GetComponent<InventoryItemController>().equippedButton.gameObject.SetActive(true);
        //}

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
            
        }
    }
}

