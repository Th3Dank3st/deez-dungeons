using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    private bool potion = false;
    public Button equippedButton;
    public Button RemoveButton;
    private float test1;
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
        var maxmpcalc = (item.maxMana * 0.01f) + 1f;
        var mpregencalc = (item.manaRegen * 0.01f) + 1f;
        var maxhpcalc = (item.maxHealth * 0.01f) +1f;
        var hpregencalc = (item.healthRegen * 0.01f) + 1f;
        var castspeedcalc = 1 - (item.castSpeed * 0.01f);
        var spelldmgcalc = (item.spellDamage * 0.01f) + 1;
        var basicspeedcalc = 1 - (item.attackSpeed * 0.01f);
        var speedcalc = (item.speed * 0.01f) + 1f;
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                PlayerMovement.Instance.UpdateHealth(+(item.healValue));
                potion = true;
                break;
            case Item.ItemType.Armor:
                    PlayerMovement.Instance.spellDamage *= spelldmgcalc;
                    PlayerMovement.Instance.cooldown1 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown2 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown3 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown4 *= castspeedcalc;
                    PlayerMovement.Instance.groundTargetCooldown *= castspeedcalc;
                    PlayerMovement.Instance.lunarCooldown *= castspeedcalc;
                    PlayerMovement.Instance.summonCooldown *= castspeedcalc;
                    PlayerMovement.Instance.FireCooldown *= castspeedcalc;

                    PlayerMovement.Instance.maxHealth *= maxhpcalc;
                    PlayerMovement.Instance.regenAmount *= hpregencalc;
                    PlayerMovement.Instance.manaRegenAmount *= mpregencalc;
                    PlayerMovement.Instance.maxMana *= maxmpcalc;
                    PlayerMovement.Instance.moveSpeed *= speedcalc;
                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));
                    PlayerMovement.Instance.basicCooldown *= basicspeedcalc;               
                break;
            case Item.ItemType.Boots:
                    PlayerMovement.Instance.spellDamage *= spelldmgcalc;
                    PlayerMovement.Instance.cooldown1 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown2 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown3 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown4 *= castspeedcalc;
                    PlayerMovement.Instance.groundTargetCooldown *= castspeedcalc;
                    PlayerMovement.Instance.lunarCooldown *= castspeedcalc;
                    PlayerMovement.Instance.summonCooldown *= castspeedcalc;
                    PlayerMovement.Instance.FireCooldown *= castspeedcalc;

                    test1 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test1 = (test1 - PlayerMovement.Instance.maxHealth);
                    PlayerMovement.Instance.maxHealth += test1;

                    PlayerMovement.Instance.regenAmount *= hpregencalc;
                    PlayerMovement.Instance.manaRegenAmount *= mpregencalc;
                    PlayerMovement.Instance.maxMana *= maxmpcalc;
                    PlayerMovement.Instance.moveSpeed *= speedcalc;
                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));
                    PlayerMovement.Instance.basicCooldown *= basicspeedcalc;
                break;
            case Item.ItemType.Staff:
                    PlayerMovement.Instance.spellDamage *= spelldmgcalc;
                    PlayerMovement.Instance.cooldown1 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown2 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown3 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown4 *= castspeedcalc;
                    PlayerMovement.Instance.groundTargetCooldown *= castspeedcalc;
                    PlayerMovement.Instance.lunarCooldown *= castspeedcalc;
                    PlayerMovement.Instance.summonCooldown *= castspeedcalc;
                    PlayerMovement.Instance.FireCooldown *= castspeedcalc;

                    PlayerMovement.Instance.maxHealth *= maxhpcalc;
                    PlayerMovement.Instance.regenAmount *= hpregencalc;
                    PlayerMovement.Instance.manaRegenAmount *= mpregencalc;
                    PlayerMovement.Instance.maxMana *= maxmpcalc;
                    PlayerMovement.Instance.moveSpeed *= speedcalc;
                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));
                    PlayerMovement.Instance.basicCooldown *= basicspeedcalc;
                break;
            case Item.ItemType.Ring:
                    PlayerMovement.Instance.spellDamage *= spelldmgcalc;
                    PlayerMovement.Instance.cooldown1 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown2 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown3 *= castspeedcalc;
                    PlayerMovement.Instance.cooldown4 *= castspeedcalc;
                    PlayerMovement.Instance.groundTargetCooldown *= castspeedcalc;
                    PlayerMovement.Instance.lunarCooldown *= castspeedcalc;
                    PlayerMovement.Instance.summonCooldown *= castspeedcalc;
                    PlayerMovement.Instance.FireCooldown *= castspeedcalc;

                    PlayerMovement.Instance.maxHealth *= maxhpcalc;
                    PlayerMovement.Instance.regenAmount *= hpregencalc;
                    PlayerMovement.Instance.manaRegenAmount *= mpregencalc;
                    PlayerMovement.Instance.maxMana *= maxmpcalc;
                    PlayerMovement.Instance.moveSpeed *= speedcalc;
                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));
                    PlayerMovement.Instance.basicCooldown *= basicspeedcalc;              
                break;
        }
        var d = PlayerMovement.Instance.moveSpeed;
        PlayerMovement.Instance.activeMoveSpeed = d;
        if (potion)
        {
            RemoveItem();
        }
        if (!potion)
        {
            equippedButton.gameObject.SetActive(true);
        }       
    }
    
    public void UnequipItem()
    {
        PlayerMovement.Instance.maxHealth -= test1;
        PlayerMovement.Instance.defense += (-(item.defense));
        PlayerMovement.Instance.attackDamage += (-(item.attackDamage));
        Debug.Log("itemUnequipped");
    }

}
