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
    private bool stat11 = false;
    private bool stat12 = false;
    private bool stat13 = false;

    private int statSelector1;
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
                if(itemz.rarity == "Magic")
                {
                    pickedUpItemText.color = Color.blue;
                }
                if (itemz.rarity == "Rare")
                {
                    pickedUpItemText.color = Color.yellow;
                }
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
            int statSelector1 = Random.Range(1, 9);
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

            if (statSelector1 == 6 && !stat6)
            {
                itemz.minDamage = Random.Range(statValueMin, (statValueMax * 0.65f));
                numberOfStats--;
                stat6 = true;
            }

            if (statSelector1 == 7 && !stat7)
            {
                itemz.maxDamage = Random.Range(statValueMin, (statValueMax * 0.65f));
                numberOfStats--;
                stat7 = true;
            }

            if (statSelector1 == 8 && !stat8)
            {
                itemz.critBonus = Random.Range((statValueMin * 0.3f), (statValueMax * 0.3f));
                numberOfStats--;
                stat8 = true;
            }
            yield return null;
        }
        /*Debug.Log(itemz.castSpeed + " cast spd");
        Debug.Log(itemz.attackDamage + " attack dmg");
        Debug.Log(itemz.attackSpeed + " attack Spd");
        Debug.Log(itemz.spellDamage + " spell Damage");
        Debug.Log(itemz.maxMana + " mana");
        Debug.Log(itemz.manaRegen + " manaregen");*/
        InventoryManager.Instance.Add(itemz);
        Destroy(gameObject);
    }

    IEnumerator RingStatSelector(int numberOfStats)
    {

        while (numberOfStats > 0)
        {
            if(itemz.itemType != Item.ItemType.Staff)
            {
                statSelector1 = Random.Range(1, 12);
            }
            if (itemz.itemType == Item.ItemType.Staff)
            {
                statSelector1 = Random.Range(1, 14);
            }

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

            if (statSelector1 == 11 && !stat11)
            {
                if (itemz.itemType == Item.ItemType.Amulet)
                {
                    itemz.critBonus = Random.Range((statValueMin * 0.1f), (statValueMax * 0.25f));
                    numberOfStats--;
                    stat11 = true;
                }

                if (itemz.itemType == Item.ItemType.Ring)
                {
                    itemz.critBonus = Random.Range((statValueMin * 0.1f), (statValueMax * 0.25f));
                    numberOfStats--;
                    stat11 = true;
                }
                if (itemz.itemType == Item.ItemType.Staff)
                {
                    itemz.critBonus = Random.Range((statValueMin * 0.2f), (statValueMax * 0.6f));
                    numberOfStats--;
                    stat11 = true;
                }

            }
            if (statSelector1 == 12 && !stat12)
            {
                itemz.maxDamage = Random.Range((statValueMin * 0.65f), (statValueMax * 0.65f));
                numberOfStats--;
                stat12 = true;
            }
            if (statSelector1 == 13 && !stat13)
            {
                itemz.minDamage = Random.Range((statValueMin * 0.65f), (statValueMax * 0.65f));
                numberOfStats--;
                stat13 = true;
            }
            yield return null;
        }
        InventoryManager.Instance.Add(itemz);
        Destroy(gameObject);
    }
}