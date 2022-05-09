using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]

public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int healValue;
    public int defense;
    public Sprite icon;
    public ItemType itemType;
    public int amount = 1;
    public int speed;

    public enum ItemType
    {
        Potion,
        Boots,
        Armor,

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
        }
    }
}
