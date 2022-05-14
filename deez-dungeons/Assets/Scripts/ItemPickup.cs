using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    //public Item itemz;
    private Text pickedUpItemText;
    private bool stat1 = false;
    private bool stat2 = false;
    private bool stat3 = false;
    private bool stat4 = false;
    private bool stat5 = false;
    private bool stat6 = false;
    private bool stat7 = false;
    private bool stat8 = false;
    private bool stat9 = false;
    private bool stat10 = false;
    public Item obj;
    private Item itemz;
    private int numberOfStats;
    private int statValueMin;
    private int statValueMax;

    private void Awake()
    {
        itemz = ScriptableObject.Instantiate(obj);
    }

    public void OnCollisionEnter2D(Collision2D other)      // the original line of code for this function is Pickup(); only
    {
        if(other.gameObject.tag == "Player")
        {
            pickedUpItemText = FindObjectOfType<Text>();
            if (pickedUpItemText.name == "ItemFoundText")
            {                
                string itemname = obj.itemName;
                pickedUpItemText.text = (itemname + " has been found!");
                Pickup();
            }            
        }
    }

    void Pickup()
    {
        if (itemz.rarity == "Magic")
        {
            numberOfStats = 2;
            statValueMin = 1;
            statValueMax = 10;
        }

        if(itemz.rarity == "Rare")
        {
            numberOfStats = 5;
            statValueMin = 5;
            statValueMax = 25;
        }

        //redpot
        if (obj.itemType == Item.ItemType.Potion)
        {
            itemz.healValue = 200;
            InventoryManager.Instance.Add(itemz);
            Destroy(gameObject);
        }

        //MagicBoots
        if (obj.itemType == Item.ItemType.Boots)
        {
            itemz.speed = Random.Range(statValueMin, statValueMax);
            itemz.defense = Random.Range(statValueMin -1, 5);
            if (itemz.rarity == "Magic")
            {
                StartCoroutine(StatSelector(numberOfStats));
            }
            if (itemz.rarity == "Rare")
            {
                StartCoroutine(RingStatSelector(numberOfStats));
            }
        }

        //MagicArmor
        if (obj.itemType == Item.ItemType.Armor)
        {
            itemz.defense = Random.Range(10, 20);
            if (itemz.rarity == "Magic")
            {
                StartCoroutine(StatSelector(numberOfStats));
            }
            if (itemz.rarity == "Rare")
            {
                StartCoroutine(RingStatSelector(numberOfStats));
            }
            
        }

        //MagicStaff
        if (obj.itemType == Item.ItemType.Staff)
        {
            itemz.attackDamage = Random.Range(5, 20);
            if(itemz.rarity == "Magic")
            {
                StartCoroutine(StatSelectorStaff(numberOfStats));
            }

            if(itemz.rarity == "Rare")
            {
                StartCoroutine(RingStatSelector(numberOfStats));
            }            
        }
        if (obj.itemType == Item.ItemType.Ring)
        {
            StartCoroutine(RingStatSelector(numberOfStats + 1));
        }

        if (obj.itemType == Item.ItemType.Amulet)
        {
            StartCoroutine(RingStatSelector(numberOfStats +1));
        }
    }


    IEnumerator StatSelector(int numberOfStats)
    {        
        while (numberOfStats > 0)
        {
            int statSelector1 = Random.Range(1, 5);
            if (statSelector1 == 1 && !stat1)
            {
                itemz.healthRegen = Random.Range(statValueMin, 20);
                numberOfStats--;
                stat1 = true;
            }

            if (statSelector1 == 2 && !stat2)
            {
                itemz.maxHealth = Random.Range(statValueMin, 20);
                numberOfStats--;
                stat2 = true;
            }

            if (statSelector1 == 3 && !stat3)
            {
                itemz.maxMana = Random.Range(statValueMin, 20);
                numberOfStats--;
                stat3 = true;
            }

            if (statSelector1 == 4 && !stat4)
            {
                itemz.manaRegen = Random.Range(statValueMin, 20);
                numberOfStats--;
                stat4 = true;
            }
            yield return null;
        }
        InventoryManager.Instance.Add(itemz);
        Destroy(gameObject);
    }

    IEnumerator StatSelectorStaff(int numberOfStats)
    {

        while (numberOfStats > 0)
        {
            int statSelector1 = Random.Range(1, 6);
            if (statSelector1 == 1 && !stat1)
            {
                itemz.attackSpeed = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat1 = true;
            }

            if (statSelector1 == 2 && !stat2)
            {
                itemz.spellDamage = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat2 = true;
            }

            if (statSelector1 == 3 && !stat3)
            {
                itemz.maxMana = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat3 = true;
            }

            if (statSelector1 == 4 && !stat4)
            {
                itemz.manaRegen = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat4 = true;
            }

            if (statSelector1 == 5 && !stat5)
            {
                itemz.castSpeed = Random.Range(statValueMin, statValueMax);
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
        Destroy(gameObject);
    }

    IEnumerator RingStatSelector(int numberOfStats)
    {

        while (numberOfStats > 0)
        {
            int statSelector1 = Random.Range(1, 11);
            if (statSelector1 == 1 && !stat1)
            {
                itemz.healthRegen = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat1 = true;
            }

            if (statSelector1 == 2 && !stat2)
            {
                itemz.maxHealth = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat2 = true;
            }

            if (statSelector1 == 3 && !stat3)
            {
                itemz.maxMana = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat3 = true;
            }

            if (statSelector1 == 4 && !stat4)
            {
                itemz.manaRegen = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat4 = true;
            }
            
            if (statSelector1 == 5 && !stat5)
            {
                itemz.attackDamage = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat5 = true;
            }

            if (statSelector1 == 6 && !stat6)
            {
                itemz.spellDamage = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat6 = true;
            }

            if (statSelector1 == 7 && !stat7)
            {
                itemz.attackSpeed = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat7 = true;
            }

            if (statSelector1 == 8 && !stat8)
            {
                itemz.castSpeed = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat8 = true;
            }
           
            if (statSelector1 == 9 && !stat9)
            {
                itemz.defense = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat9 = true;
            }

            if (statSelector1 == 10 && !stat10)
            {
                itemz.speed = Random.Range(statValueMin, statValueMax);
                numberOfStats--;
                stat10 = true;
            }
            yield return null;
        }
        InventoryManager.Instance.Add(itemz);
        Destroy(gameObject);
    }
}