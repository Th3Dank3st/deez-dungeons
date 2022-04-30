using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)      //adding code here come back to debug
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                PlayerMovement.Instance.UpdateHealth(+(item.value));
                break;
            //case Item.ItemType.Sword:
            //whatever the sword does or however we equip it here, not sure which one yet.
            //  break;

        }
        RemoveItem();
    }
}
