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
        var castspeedcalc = 1 - (item.castSpeed * 0.01f);
        //var spelldmgcalc = (item.spellDamage * 0.01f) + 1;
        var basicspeedcalc = 1 - (item.attackSpeed * 0.01f);
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
            case Item.ItemType.Staff:
                PlayerMovement.Instance.attackDamage += (+(item.attackDamage));
                PlayerMovement.Instance.basicCooldown *= basicspeedcalc;
                break;
            case Item.ItemType.Ring:
                PlayerMovement.Instance.cooldown1 *= castspeedcalc;
                PlayerMovement.Instance.cooldown2 *= castspeedcalc;
                PlayerMovement.Instance.cooldown3 *= castspeedcalc;
                PlayerMovement.Instance.cooldown4 *= castspeedcalc;
                PlayerMovement.Instance.groundTargetCooldown *= castspeedcalc;
                PlayerMovement.Instance.lunarCooldown *= castspeedcalc;
                PlayerMovement.Instance.summonCooldown *= castspeedcalc;
                PlayerMovement.Instance.FireCooldown *= castspeedcalc;
                break;
        }
        var d = PlayerMovement.Instance.moveSpeed;
        PlayerMovement.Instance.activeMoveSpeed = d;
        RemoveItem();
    }
}
