using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]

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

    public enum ItemType
    {
        Potion,
        Boots,
        Armor,
        Staff,
        Ring,

    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
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
