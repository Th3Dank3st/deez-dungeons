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
            //stats
            
            var Tooltip = obj.transform.Find("ToolTip").GetComponent<RectTransform>();
            var text1 = Tooltip.Find("Text1").GetComponent<Text>();
            var f = item.defense.ToString();
            if (f.Length > 4)
            {
                f = f.Substring(0, 4);
            }
            text1.text = ("Def " + f);
            if (item.defense > 0)
            {
                text1.color = Color.green;
            }
            
            var text2 = Tooltip.Find("Text2").GetComponent<Text>();
            var a = item.maxHealth.ToString();
            if (a.Length > 4)
            {
                a = a.Substring(0, 4);
            }
            text2.text = ("HP " + a);
            if (item.maxHealth > 0)
            {
                text2.color = Color.green;
            }
            var text3 = Tooltip.Find("Text3").GetComponent<Text>();
            text3.text = ("HP/5 " + item.healthRegen.ToString());
            if (item.healthRegen > 0)
            {
                text3.color = Color.green;
            }
            var text4 = Tooltip.Find("Text4").GetComponent<Text>();
            var z = item.speed.ToString();
            if (z.Length > 4)
            {
                z = z.Substring(0, 4);
            }
            text4.text = ("Speed " + z);
            if (item.speed > 0)
            {
                text4.color = Color.green;
            }
            var text5 = Tooltip.Find("Text5").GetComponent<Text>();
            text5.text = ("AttackDMG " + item.attackDamage.ToString());
            if (item.attackDamage > 0)
            {
                text5.color = Color.green;
            }
            var text6 = Tooltip.Find("Text6").GetComponent<Text>();
            var y = item.attackSpeed.ToString();
            if (y.Length > 4)
            {
                y = y.Substring(0, 4);
            }
            text6.text = ("AttackSPD " + y);
            if (item.attackSpeed > 0)
            {
                text6.color = Color.green;
            }
            var text7 = Tooltip.Find("Text7").GetComponent<Text>();
            text7.text = ("SpellDMG " + item.spellDamage.ToString());
            if (item.spellDamage > 0)
            {
                text7.color = Color.green;
            }
            var text8 = Tooltip.Find("Text8").GetComponent<Text>();
            var L = item.castSpeed.ToString();
            if (L.Length > 4)
            {
                L = L.Substring(0, 4);
            }
            text8.text = ("CastSPD " + L);
            if (item.castSpeed > 0)
            {
                text8.color = Color.green;
            }
            var text9 = Tooltip.Find("Text9").GetComponent<Text>();
            text9.text = ("MP " + item.maxMana.ToString());
            if (item.maxMana > 0)
            {
                text9.color = Color.green;
            }
            var text10 = Tooltip.Find("Text10").GetComponent<Text>();
            text10.text = ("MP/5 " + item.manaRegen.ToString());
            if (item.manaRegen > 0)
            {
                text10.color = Color.green;
            }
            var text11 = Tooltip.Find("Text11").GetComponent<Text>();
            text11.text = ("Potion +" + item.healValue.ToString() + "HP");
            if (item.healValue > 0)
            {
                text11.color = Color.green;
            }
            var text12 = Tooltip.Find("Text12").GetComponent<Text>();
            
            var d = item.critBonus.ToString();
            if (d.Length > 4)
            {
                d = d.Substring(0, 4);
            }
            
            text12.text = ("Crit " + d);
            if (item.critBonus > 0)
            {
                text12.color = Color.green;
            }
            var text13 = Tooltip.Find("Text13").GetComponent<Text>();
            var c = item.minDamage.ToString();
            if (c.Length > 4)
            {
                c = c.Substring(0, 4);
            }
            text13.text = ("MinDMG " + c);
            if (item.minDamage > 0)
            {
                text13.color = Color.green;
            }
            var text14 = Tooltip.Find("Text14").GetComponent<Text>();
            var v = item.maxDamage.ToString();
            if (v.Length > 4)
            {
                v = v.Substring(0, 4);
            }
            text14.text = ("MaxDMG " + v);
            if (item.maxDamage > 0)
            {
                text14.color = Color.green;
            }
            var tooltipName = Tooltip.Find("TextName").GetComponent<Text>();
            var description = Tooltip.Find("Description").GetComponent<Text>();
            if (item.rarity != "Unique")
            {
                tooltipName.text = item.rarity + " " + item.itemName;
            }
            if(item.rarity == "Unique")
            {
                //list of item descriptions identied by item name
                tooltipName.text = item.itemName;
            }            
            itemName.text = item.itemName;
            if (item.rarity == "Magic")
            {
                description.text = "An item with a simple enchantment";
                tooltipName.color = Color.blue;
                itemName.color = Color.blue;
            }
            if(item.rarity == "Rare")
            {
                description.text = "An item with a very expensive enchantment";
                tooltipName.color = Color.yellow;
                itemName.color = Color.yellow;
            }
            if(item.rarity == "Unique")
            {
                description.text = "An item of unknown origin possessing vast power";
                tooltipName.color = Color.magenta;
                itemName.color = Color.magenta;
            }

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
        if (!EnableRemove.isOn)
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

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
            
        }
    }
}

