using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public float healValue;
    public float defense;
    public Sprite icon;
    public ItemType itemType;
    public int amount = 1;
    public float speed;
    public float attackDamage;
    public float attackSpeed;
    public float spellDamage;
    public float castSpeed;
    public float maxMana;
    public float manaRegen;
    public float maxHealth;
    public float healthRegen;
    public bool itemEquipped;

    public float test1;
    public float testc1;
    public float testc2;
    public float testc3;
    public float testc4;
    public float testc5;
    public float testc6;
    public float testc7;
    public float testc8;
    public float test3;
    public float test4;
    public float test5;
    public float test6;
    public float test7;
    public float test8;
    public string rarity;

    public enum ItemType
    {
        Potion,
        Boots,
        Armor,
        Staff,
        Ring,
        Amulet,

    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Amulet:
                return false;
            case ItemType.Potion:
                return true;
            case ItemType.Boots:
                return false;
            case ItemType.Armor:
                return false;
            case ItemType.Staff:
                return false;
            case ItemType.Ring:
                return false;
        }
    }
}
