using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Item itemz;
    private Text pickedUpItemText;
    private bool stat1 = false;
    private bool stat2 = false;
    private bool stat3 = false;
    private bool stat4 = false;

    public void OnCollisionEnter2D(Collision2D other)      // the original line of code for this function is Pickup(); only
    {
        if(other.gameObject.tag == "Player")
        {
            pickedUpItemText = FindObjectOfType<Text>();
            if (pickedUpItemText.name == "ItemFoundText")
            {
                string itemname = itemz.itemName;
                pickedUpItemText.text = (itemname + " has been found!");
                Pickup();
            }            
        }
    }

    void Pickup()
    {   
        //MagicBoots
       if (itemz.itemType == Item.ItemType.Boots)
        {
            itemz.speed = Random.Range(1, 20);
            itemz.defense = Random.Range(3, 5);
            StartCoroutine(StatSelector(1));
           
        }

        //MagicArmor
        if(itemz.itemType == Item.ItemType.Armor)
        {
            itemz.defense = Random.Range(1, 20);
            StartCoroutine(StatSelector(3));           
        }
    }



    IEnumerator StatSelector(int numberOfStats)
    {
        
        while (numberOfStats > 0)
        {
            int statSelector1 = Random.Range(1, 5);
            if (statSelector1 == 1 && !stat1)
            {
                itemz.healthRegen = Random.Range(1, 20);
                numberOfStats--;
                stat1 = true;
            }

            if (statSelector1 == 2 && !stat2)
            {
                itemz.maxHealth = Random.Range(1, 20);
                numberOfStats--;
                stat2 = true;
            }

            if (statSelector1 == 3 && !stat3)
            {
                itemz.maxMana = Random.Range(1, 20);
                numberOfStats--;
                stat3 = true;
            }

            if (statSelector1 == 4 && !stat4)
            {
                itemz.manaRegen = Random.Range(1, 20);
                numberOfStats--;
                stat4 = true;
            }
            yield return null;
        }
        Debug.Log(itemz.speed + " spd");
        Debug.Log(itemz.defense + " def");
        Debug.Log(itemz.maxHealth + " hp");
        Debug.Log(itemz.healthRegen + " hpRegen");
        Debug.Log(itemz.maxMana + " mana");
        Debug.Log(itemz.manaRegen + " manaregen");

        InventoryManager.Instance.Add(itemz);
        itemz.healValue = 0;
        itemz.defense = 0;
        itemz.speed = 0;
        itemz.attackDamage = 0;
        itemz.attackSpeed = 0;
        itemz.spellDamage = 0;
        itemz.castSpeed = 0;
        itemz.maxMana = 0;
        itemz.manaRegen = 0;
        itemz.maxHealth = 0;
        itemz.healthRegen = 0;
        Destroy(gameObject);
    }
}