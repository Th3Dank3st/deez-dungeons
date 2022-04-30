using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]

public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public ItemType itemType;
    public int amount = 1;

    public enum ItemType
    {
        Potion,
        Sword,

    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
                case ItemType.Potion:
                return true;
                case ItemType.Sword:
                return false;
        }
    }
}
