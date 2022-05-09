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


    //var totalDefense = 1f - (defense * 0.01f);
    //currentHealth += (damage* totalDefense);
    


    public void UseItem()
    {
        var speedcalc = (item.speed * 0.01f) + 1f;
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                PlayerMovement.Instance.UpdateHealth(+(item.healValue));
                break;
            case Item.ItemType.Armor:
                PlayerMovement.Instance.defense += (+(item.defense));
              break;
            case Item.ItemType.Boots:
                PlayerMovement.Instance.moveSpeed *= speedcalc;
                PlayerMovement.Instance.defense += (+(item.defense));
                break;
        }
        var d = PlayerMovement.Instance.moveSpeed;
        PlayerMovement.Instance.activeMoveSpeed = d;
        RemoveItem();
    }
}
