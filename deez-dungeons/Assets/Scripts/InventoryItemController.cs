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
    private float testc1;
    private float testc2;
    private float testc3;
    private float testc4;
    private float testc5;
    private float testc6;
    private float testc7;
    private float testc8;
    private float test3;
    private float test4;
    private float test5;
    private float test6;
    private float test7;
    private float test8;
    
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
                if(PlayerMovement.Instance.Armor1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    PlayerMovement.Instance.spellDamage += test1;


                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    PlayerMovement.Instance.cooldown2 -= testc2;


                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    PlayerMovement.Instance.cooldown3 -= testc3;


                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    PlayerMovement.Instance.cooldown4 -= testc4;


                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;


                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    PlayerMovement.Instance.lunarCooldown -= testc6;



                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    PlayerMovement.Instance.summonCooldown -= testc7;


                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    PlayerMovement.Instance.maxHealth += test3;


                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    PlayerMovement.Instance.regenAmount += test4;


                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    PlayerMovement.Instance.manaRegenAmount += test5;


                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    PlayerMovement.Instance.moveSpeed += test7;


                    PlayerMovement.Instance.defense += (+(item.defense));


                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));


                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Armor1 = true;
                    equippedButton.gameObject.SetActive(true);
                }                
                break;
            case Item.ItemType.Boots:
                if (PlayerMovement.Instance.Boots1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    PlayerMovement.Instance.spellDamage += test1;


                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    PlayerMovement.Instance.cooldown2 -= testc2;


                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    PlayerMovement.Instance.cooldown3 -= testc3;


                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    PlayerMovement.Instance.cooldown4 -= testc4;


                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;


                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    PlayerMovement.Instance.lunarCooldown -= testc6;



                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    PlayerMovement.Instance.summonCooldown -= testc7;


                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    PlayerMovement.Instance.maxHealth += test3;


                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    PlayerMovement.Instance.regenAmount += test4;


                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    PlayerMovement.Instance.manaRegenAmount += test5;


                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    PlayerMovement.Instance.moveSpeed += test7;


                    PlayerMovement.Instance.defense += (+(item.defense));


                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));


                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Boots1 = true;
                    equippedButton.gameObject.SetActive(true);
                }
                break;
            case Item.ItemType.Staff:
                if (PlayerMovement.Instance.Staff1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    PlayerMovement.Instance.spellDamage += test1;


                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    PlayerMovement.Instance.cooldown2 -= testc2;


                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    PlayerMovement.Instance.cooldown3 -= testc3;


                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    PlayerMovement.Instance.cooldown4 -= testc4;


                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;


                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    PlayerMovement.Instance.lunarCooldown -= testc6;



                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    PlayerMovement.Instance.summonCooldown -= testc7;


                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    PlayerMovement.Instance.maxHealth += test3;


                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    PlayerMovement.Instance.regenAmount += test4;


                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    PlayerMovement.Instance.manaRegenAmount += test5;


                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    PlayerMovement.Instance.moveSpeed += test7;


                    PlayerMovement.Instance.defense += (+(item.defense));


                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));


                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Staff1 = true;
                    equippedButton.gameObject.SetActive(true);
                }
                break;
            case Item.ItemType.Ring:
                if (PlayerMovement.Instance.Ring1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    PlayerMovement.Instance.spellDamage += test1;


                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    PlayerMovement.Instance.cooldown2 -= testc2;


                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    PlayerMovement.Instance.cooldown3 -= testc3;


                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    PlayerMovement.Instance.cooldown4 -= testc4;


                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;


                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    PlayerMovement.Instance.lunarCooldown -= testc6;



                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    PlayerMovement.Instance.summonCooldown -= testc7;


                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    PlayerMovement.Instance.maxHealth += test3;


                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    PlayerMovement.Instance.regenAmount += test4;


                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    PlayerMovement.Instance.manaRegenAmount += test5;


                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    PlayerMovement.Instance.moveSpeed += test7;


                    PlayerMovement.Instance.defense += (+(item.defense));


                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));


                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Ring1 = true;
                    equippedButton.gameObject.SetActive(true);
                }
                break;
        }
        var d = PlayerMovement.Instance.moveSpeed;
        PlayerMovement.Instance.activeMoveSpeed = d;
        if (potion)
        {
            RemoveItem();
        }
    }
    
    public void UnequipItem()
    {

        PlayerMovement.Instance.spellDamage -= test1;

        PlayerMovement.Instance.cooldown1 += testc1;
        PlayerMovement.Instance.cooldown2 += testc2;
        PlayerMovement.Instance.cooldown3 += testc3;
        PlayerMovement.Instance.cooldown4 += testc4;
        PlayerMovement.Instance.groundTargetCooldown += testc5;
        PlayerMovement.Instance.lunarCooldown += testc6;
        PlayerMovement.Instance.summonCooldown += testc7;
        PlayerMovement.Instance.FireCooldown += testc8;

        PlayerMovement.Instance.maxHealth -= test3;
        PlayerMovement.Instance.regenAmount -= test4;
        PlayerMovement.Instance.manaRegenAmount -= test5;
        PlayerMovement.Instance.maxMana -= test6;
        PlayerMovement.Instance.moveSpeed -= test7;
        PlayerMovement.Instance.defense += (-(item.defense));
        PlayerMovement.Instance.attackDamage += (-(item.attackDamage));
        PlayerMovement.Instance.basicCooldown += test8;
        var d = PlayerMovement.Instance.moveSpeed;
        PlayerMovement.Instance.activeMoveSpeed = d;
        if (item.itemType == Item.ItemType.Armor)
        {
            PlayerMovement.Instance.Armor1 = false;
        }
        if (item.itemType == Item.ItemType.Ring)
        {
            PlayerMovement.Instance.Ring1 = false;
        }
        if (item.itemType == Item.ItemType.Staff)
        {
            PlayerMovement.Instance.Staff1 = false;
        }
        if (item.itemType == Item.ItemType.Boots)
        {
            PlayerMovement.Instance.Boots1 = false;
        }
        Debug.Log("itemUnequipped");
    }

}
