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
    private bool stat5 = false;

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
        //redpot
        if (itemz.itemType == Item.ItemType.Potion)
        {
            InventoryManager.Instance.Add(itemz);
            Destroy(gameObject);
        }
        //MagicBoots
        if (itemz.itemType == Item.ItemType.Boots)
        {
            itemz.speed = Random.Range(0, 20);
            itemz.defense = Random.Range(0, 5);
            StartCoroutine(StatSelector(2));
        }

        //MagicArmor
        if (itemz.itemType == Item.ItemType.Armor)
        {
            itemz.defense = Random.Range(1, 20);
            StartCoroutine(StatSelector(2));
        }

        //MagicStaff
        if (itemz.itemType == Item.ItemType.Staff)
        {
            itemz.attackDamage = Random.Range(1, 20);
            StartCoroutine(StatSelectorStaff(2));
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

    IEnumerator StatSelectorStaff(int numberOfStats)
    {

        while (numberOfStats > 0)
        {
            int statSelector1 = Random.Range(1, 6);
            if (statSelector1 == 1 && !stat1)
            {
                itemz.attackSpeed = Random.Range(1, 20);
                numberOfStats--;
                stat1 = true;
            }

            if (statSelector1 == 2 && !stat2)
            {
                itemz.spellDamage = Random.Range(1, 20);
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

            if (statSelector1 == 5 && !stat5)
            {
                itemz.castSpeed = Random.Range(1, 20);
                numberOfStats--;
                stat5 = true;
            }
            yield return null;
        }
        Debug.Log(itemz.castSpeed + " cast spd");
        Debug.Log(itemz.attackDamage + " attack dmg");
        Debug.Log(itemz.attackSpeed + " attack Spd");
        Debug.Log(itemz.spellDamage + " spell Damage");
        Debug.Log(itemz.maxMana + " mana");
        Debug.Log(itemz.manaRegen + " manaregen");

        InventoryManager.Instance.Add(itemz);
        itemz.attackDamage = 0;
        itemz.attackSpeed = 0;
        itemz.spellDamage = 0;
        itemz.castSpeed = 0;
        itemz.maxMana = 0;
        itemz.manaRegen = 0;
        Destroy(gameObject);
    }
}