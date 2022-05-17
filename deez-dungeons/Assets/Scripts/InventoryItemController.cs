using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Item item;
    private bool potion = false;
    public Button equippedButton;
    public Button RemoveButton;
    private float test;
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

    private void Awake()
    {
        /*itemy.defense = item.defense;
        itemy.speed = item.speed;
        itemy.attackDamage = item.attackDamage;
        itemy.attackSpeed = item.attackSpeed;
        itemy.spellDamage = item.spellDamage;
        itemy.castSpeed = item.castSpeed;
        itemy.maxMana = item.maxMana;
        itemy.manaRegen = item.manaRegen;
        itemy.maxHealth = item.maxHealth;
        itemy.healthRegen = item.healthRegen;*/

    }
    public void RemoveItem()
    {
        UnequipItem();
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
                    item.test1 = test1;
                    PlayerMovement.Instance.spellDamage += test1;

                    //for player cooldown stat
                    test = PlayerMovement.Instance.cooldown * castspeedcalc;
                    test = (PlayerMovement.Instance.cooldown - test);
                    PlayerMovement.Instance.test = test;
                    PlayerMovement.Instance.cooldown -= test;


                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    item.testc1 = testc1;
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    item.testc2 = testc2;
                    PlayerMovement.Instance.cooldown2 -= testc2;

                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    item.testc3 = testc3;
                    PlayerMovement.Instance.cooldown3 -= testc3;

                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    item.testc4 = testc4;
                    PlayerMovement.Instance.cooldown4 -= testc4;

                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    item.testc5 = testc5;
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;

                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    item.testc6 = testc6;
                    PlayerMovement.Instance.lunarCooldown -= testc6;

                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    item.testc7 = testc7;
                    PlayerMovement.Instance.summonCooldown -= testc7;

                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    item.testc8 = testc8;
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    item.test3 = test3;
                    PlayerMovement.Instance.maxHealth += test3;

                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    item.test4 = test4;
                    PlayerMovement.Instance.regenAmount += test4;

                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    item.test5 = test5;
                    PlayerMovement.Instance.manaRegenAmount += test5;

                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    item.test6 = test6;
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    item.test7 = test7;
                    PlayerMovement.Instance.moveSpeed += test7;

                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.critBonus += (+(item.critBonus));
                    PlayerMovement.Instance.minDamage += (+(item.minDamage));
                    PlayerMovement.Instance.maxDamage += (+(item.maxDamage));

                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));

                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    item.test8 = test8;
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Armor1 = true;
                    equippedButton.gameObject.SetActive(true);
                    item.itemEquipped = true;
                    GameObject.Find("Player Stats").GetComponent<PlayerStats>().SetPlayerStats();
                }                
                break;
            case Item.ItemType.Boots:
                if (PlayerMovement.Instance.Boots1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    item.test1 = test1;
                    PlayerMovement.Instance.spellDamage += test1;

                    //for player cooldown stat
                    test = PlayerMovement.Instance.cooldown * castspeedcalc;
                    test = (PlayerMovement.Instance.cooldown - test);
                    PlayerMovement.Instance.test = test;
                    PlayerMovement.Instance.cooldown -= test;

                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    item.testc1 = testc1;
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    item.testc2 = testc2;
                    PlayerMovement.Instance.cooldown2 -= testc2;

                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    item.testc3 = testc3;
                    PlayerMovement.Instance.cooldown3 -= testc3;

                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    item.testc4 = testc4;
                    PlayerMovement.Instance.cooldown4 -= testc4;

                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    item.testc5 = testc5;
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;

                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    item.testc6 = testc6;
                    PlayerMovement.Instance.lunarCooldown -= testc6;

                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    item.testc7 = testc7;
                    PlayerMovement.Instance.summonCooldown -= testc7;

                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    item.testc8 = testc8;
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    item.test3 = test3;
                    PlayerMovement.Instance.maxHealth += test3;

                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    item.test4 = test4;
                    PlayerMovement.Instance.regenAmount += test4;

                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    item.test5 = test5;
                    PlayerMovement.Instance.manaRegenAmount += test5;

                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    item.test6 = test6;
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    item.test7 = test7;
                    PlayerMovement.Instance.moveSpeed += test7;

                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.critBonus += (+(item.critBonus));
                    PlayerMovement.Instance.minDamage += (+(item.minDamage));
                    PlayerMovement.Instance.maxDamage += (+(item.maxDamage));

                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));

                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    item.test8 = test8;
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Boots1 = true;
                    equippedButton.gameObject.SetActive(true);
                    item.itemEquipped = true;
                    GameObject.Find("Player Stats").GetComponent<PlayerStats>().SetPlayerStats();
                }
                break;
            case Item.ItemType.Staff:
                if (PlayerMovement.Instance.Staff1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    item.test1 = test1;
                    PlayerMovement.Instance.spellDamage += test1;

                    //for player cooldown stat
                    test = PlayerMovement.Instance.cooldown * castspeedcalc;
                    test = (PlayerMovement.Instance.cooldown - test);
                    PlayerMovement.Instance.test = test;
                    PlayerMovement.Instance.cooldown -= test;

                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    item.testc1 = testc1;
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    item.testc2 = testc2;
                    PlayerMovement.Instance.cooldown2 -= testc2;

                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    item.testc3 = testc3;
                    PlayerMovement.Instance.cooldown3 -= testc3;

                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    item.testc4 = testc4;
                    PlayerMovement.Instance.cooldown4 -= testc4;

                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    item.testc5 = testc5;
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;

                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    item.testc6 = testc6;
                    PlayerMovement.Instance.lunarCooldown -= testc6;

                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    item.testc7 = testc7;
                    PlayerMovement.Instance.summonCooldown -= testc7;

                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    item.testc8 = testc8;
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    item.test3 = test3;
                    PlayerMovement.Instance.maxHealth += test3;

                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    item.test4 = test4;
                    PlayerMovement.Instance.regenAmount += test4;

                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    item.test5 = test5;
                    PlayerMovement.Instance.manaRegenAmount += test5;

                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    item.test6 = test6;
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    item.test7 = test7;
                    PlayerMovement.Instance.moveSpeed += test7;

                    PlayerMovement.Instance.defense += (+(item.defense));

                    PlayerMovement.Instance.critBonus += (+(item.critBonus));
                    PlayerMovement.Instance.minDamage += (+(item.minDamage));
                    PlayerMovement.Instance.maxDamage += (+(item.maxDamage));

                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));

                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    item.test8 = test8;
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Staff1 = true;
                    equippedButton.gameObject.SetActive(true);
                    item.itemEquipped = true;
                    GameObject.Find("Player Stats").GetComponent<PlayerStats>().SetPlayerStats();

                }
                break;
            case Item.ItemType.Ring:
                if (PlayerMovement.Instance.Ring1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    item.test1 = test1;
                    PlayerMovement.Instance.spellDamage += test1;

                    //for player cooldown stat
                    test = PlayerMovement.Instance.cooldown * castspeedcalc;
                    test = (PlayerMovement.Instance.cooldown - test);
                    PlayerMovement.Instance.test = test;
                    PlayerMovement.Instance.cooldown -= test;

                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    item.testc1 = testc1;
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    item.testc2 = testc2;
                    PlayerMovement.Instance.cooldown2 -= testc2;

                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    item.testc3 = testc3;
                    PlayerMovement.Instance.cooldown3 -= testc3;

                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    item.testc4 = testc4;
                    PlayerMovement.Instance.cooldown4 -= testc4;

                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    item.testc5 = testc5;
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;

                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    item.testc6 = testc6;
                    PlayerMovement.Instance.lunarCooldown -= testc6;

                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    item.testc7 = testc7;
                    PlayerMovement.Instance.summonCooldown -= testc7;

                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    item.testc8 = testc8;
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    item.test3 = test3;
                    PlayerMovement.Instance.maxHealth += test3;

                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    item.test4 = test4;
                    PlayerMovement.Instance.regenAmount += test4;

                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    item.test5 = test5;
                    PlayerMovement.Instance.manaRegenAmount += test5;

                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    item.test6 = test6;
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    item.test7 = test7;
                    PlayerMovement.Instance.moveSpeed += test7;

                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.critBonus += (+(item.critBonus));
                    PlayerMovement.Instance.minDamage += (+(item.minDamage));
                    PlayerMovement.Instance.maxDamage += (+(item.maxDamage));

                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));

                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    item.test8 = test8;
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Ring1 = true;
                    equippedButton.gameObject.SetActive(true);
                    item.itemEquipped = true;
                    GameObject.Find("Player Stats").GetComponent<PlayerStats>().SetPlayerStats();

                }
                break;
            case Item.ItemType.Amulet:
                if (PlayerMovement.Instance.Amulet1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    item.test1 = test1;
                    PlayerMovement.Instance.spellDamage += test1;

                    //for player cooldown stat
                    test = 100 * castspeedcalc;
                    test = (100 - test);
                    PlayerMovement.Instance.test = test;
                    PlayerMovement.Instance.cooldown -= test;

                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    item.testc1 = testc1;
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    item.testc2 = testc2;
                    PlayerMovement.Instance.cooldown2 -= testc2;

                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    item.testc3 = testc3;
                    PlayerMovement.Instance.cooldown3 -= testc3;

                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    item.testc4 = testc4;
                    PlayerMovement.Instance.cooldown4 -= testc4;

                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    item.testc5 = testc5;
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;

                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    item.testc6 = testc6;
                    PlayerMovement.Instance.lunarCooldown -= testc6;

                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    item.testc7 = testc7;
                    PlayerMovement.Instance.summonCooldown -= testc7;

                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    item.testc8 = testc8;
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    item.test3 = test3;
                    PlayerMovement.Instance.maxHealth += test3;

                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    item.test4 = test4;
                    PlayerMovement.Instance.regenAmount += test4;

                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    item.test5 = test5;
                    PlayerMovement.Instance.manaRegenAmount += test5;

                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    item.test6 = test6;
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    item.test7 = test7;
                    PlayerMovement.Instance.moveSpeed += test7;

                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.critBonus += (+(item.critBonus));
                    PlayerMovement.Instance.minDamage += (+(item.minDamage));
                    PlayerMovement.Instance.maxDamage += (+(item.maxDamage));

                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));

                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    item.test8 = test8;
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Amulet1 = true;
                    equippedButton.gameObject.SetActive(true);
                    item.itemEquipped = true;
                    GameObject.Find("Player Stats").GetComponent<PlayerStats>().SetPlayerStats();

                }
                break;
            case Item.ItemType.Head:
                if (PlayerMovement.Instance.Head1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    item.test1 = test1;
                    PlayerMovement.Instance.spellDamage += test1;

                    //for player cooldown stat
                    test = PlayerMovement.Instance.cooldown * castspeedcalc;
                    test = (PlayerMovement.Instance.cooldown - test);
                    PlayerMovement.Instance.test = test;
                    PlayerMovement.Instance.cooldown -= test;

                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    item.testc1 = testc1;
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    item.testc2 = testc2;
                    PlayerMovement.Instance.cooldown2 -= testc2;

                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    item.testc3 = testc3;
                    PlayerMovement.Instance.cooldown3 -= testc3;

                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    item.testc4 = testc4;
                    PlayerMovement.Instance.cooldown4 -= testc4;

                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    item.testc5 = testc5;
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;

                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    item.testc6 = testc6;
                    PlayerMovement.Instance.lunarCooldown -= testc6;

                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    item.testc7 = testc7;
                    PlayerMovement.Instance.summonCooldown -= testc7;

                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    item.testc8 = testc8;
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    item.test3 = test3;
                    PlayerMovement.Instance.maxHealth += test3;

                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    item.test4 = test4;
                    PlayerMovement.Instance.regenAmount += test4;

                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    item.test5 = test5;
                    PlayerMovement.Instance.manaRegenAmount += test5;

                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    item.test6 = test6;
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    item.test7 = test7;
                    PlayerMovement.Instance.moveSpeed += test7;

                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.critBonus += (+(item.critBonus));
                    PlayerMovement.Instance.minDamage += (+(item.minDamage));
                    PlayerMovement.Instance.maxDamage += (+(item.maxDamage));

                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));

                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    item.test8 = test8;
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Head1 = true;
                    equippedButton.gameObject.SetActive(true);
                    item.itemEquipped = true;
                    GameObject.Find("Player Stats").GetComponent<PlayerStats>().SetPlayerStats();
                }
                break;
            case Item.ItemType.Gloves:
                if (PlayerMovement.Instance.Gloves1 == false)
                {
                    test1 = PlayerMovement.Instance.spellDamage * spelldmgcalc;
                    test1 = (test1 - PlayerMovement.Instance.spellDamage);
                    item.test1 = test1;
                    PlayerMovement.Instance.spellDamage += test1;

                    //for player cooldown stat
                    test = PlayerMovement.Instance.cooldown * castspeedcalc;
                    test = (PlayerMovement.Instance.cooldown - test);
                    PlayerMovement.Instance.test = test;
                    PlayerMovement.Instance.cooldown -= test;

                    testc1 = PlayerMovement.Instance.cooldown1 * castspeedcalc;
                    testc1 = (PlayerMovement.Instance.cooldown1 - testc1);
                    item.testc1 = testc1;
                    PlayerMovement.Instance.cooldown1 -= testc1;

                    testc2 = PlayerMovement.Instance.cooldown2 * castspeedcalc;
                    testc2 = (PlayerMovement.Instance.cooldown2 - testc2);
                    item.testc2 = testc2;
                    PlayerMovement.Instance.cooldown2 -= testc2;

                    testc3 = PlayerMovement.Instance.cooldown3 * castspeedcalc;
                    testc3 = (PlayerMovement.Instance.cooldown3 - testc3);
                    item.testc3 = testc3;
                    PlayerMovement.Instance.cooldown3 -= testc3;

                    testc4 = PlayerMovement.Instance.cooldown4 * castspeedcalc;
                    testc4 = (PlayerMovement.Instance.cooldown4 - testc4);
                    item.testc4 = testc4;
                    PlayerMovement.Instance.cooldown4 -= testc4;

                    testc5 = PlayerMovement.Instance.groundTargetCooldown * castspeedcalc;
                    testc5 = (PlayerMovement.Instance.groundTargetCooldown - testc5);
                    item.testc5 = testc5;
                    PlayerMovement.Instance.groundTargetCooldown -= testc5;

                    testc6 = PlayerMovement.Instance.lunarCooldown * castspeedcalc;
                    testc6 = (PlayerMovement.Instance.lunarCooldown - testc6);
                    item.testc6 = testc6;
                    PlayerMovement.Instance.lunarCooldown -= testc6;

                    testc7 = PlayerMovement.Instance.summonCooldown * castspeedcalc;
                    testc7 = (PlayerMovement.Instance.summonCooldown - testc7);
                    item.testc7 = testc7;
                    PlayerMovement.Instance.summonCooldown -= testc7;

                    testc8 = PlayerMovement.Instance.FireCooldown * castspeedcalc;
                    testc8 = (PlayerMovement.Instance.FireCooldown - testc8);
                    item.testc8 = testc8;
                    PlayerMovement.Instance.FireCooldown -= testc8;

                    test3 = PlayerMovement.Instance.maxHealth * maxhpcalc;
                    test3 = (test3 - PlayerMovement.Instance.maxHealth);
                    item.test3 = test3;
                    PlayerMovement.Instance.maxHealth += test3;

                    test4 = PlayerMovement.Instance.regenAmount * hpregencalc;
                    test4 = (test4 - PlayerMovement.Instance.regenAmount);
                    item.test4 = test4;
                    PlayerMovement.Instance.regenAmount += test4;

                    test5 = PlayerMovement.Instance.manaRegenAmount * mpregencalc;
                    test5 = (test5 - PlayerMovement.Instance.manaRegenAmount);
                    item.test5 = test5;
                    PlayerMovement.Instance.manaRegenAmount += test5;

                    test6 = PlayerMovement.Instance.maxMana * maxmpcalc;
                    test6 = (test6 - PlayerMovement.Instance.maxMana);
                    item.test6 = test6;
                    PlayerMovement.Instance.maxMana += test6;

                    test7 = PlayerMovement.Instance.moveSpeed * speedcalc;
                    test7 = (test7 - PlayerMovement.Instance.moveSpeed);
                    item.test7 = test7;
                    PlayerMovement.Instance.moveSpeed += test7;

                    PlayerMovement.Instance.defense += (+(item.defense));
                    PlayerMovement.Instance.critBonus += (+(item.critBonus));
                    PlayerMovement.Instance.minDamage += (+(item.minDamage));
                    PlayerMovement.Instance.maxDamage += (+(item.maxDamage));

                    PlayerMovement.Instance.attackDamage += (+(item.attackDamage));

                    test8 = PlayerMovement.Instance.basicCooldown * basicspeedcalc;
                    test8 = (PlayerMovement.Instance.basicCooldown - test8);
                    item.test8 = test8;
                    PlayerMovement.Instance.basicCooldown -= test8;
                    PlayerMovement.Instance.Gloves1 = true;
                    equippedButton.gameObject.SetActive(true);
                    item.itemEquipped = true;
                    GameObject.Find("Player Stats").GetComponent<PlayerStats>().SetPlayerStats();
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
        item.itemEquipped = false;

        PlayerMovement.Instance.spellDamage -= item.test1;
        PlayerMovement.Instance.cooldown += PlayerMovement.Instance.test;
        PlayerMovement.Instance.cooldown1 += item.testc1;
        PlayerMovement.Instance.cooldown2 += item.testc2;
        PlayerMovement.Instance.cooldown3 += item.testc3;
        PlayerMovement.Instance.cooldown4 += item.testc4;
        PlayerMovement.Instance.groundTargetCooldown += item.testc5;
        PlayerMovement.Instance.lunarCooldown += item.testc6;
        PlayerMovement.Instance.summonCooldown += item.testc7;
        PlayerMovement.Instance.FireCooldown += item.testc8;

        PlayerMovement.Instance.maxHealth -= item.test3;
        PlayerMovement.Instance.regenAmount -= item.test4;
        PlayerMovement.Instance.manaRegenAmount -= item.test5;
        PlayerMovement.Instance.maxMana -= item.test6;
        PlayerMovement.Instance.moveSpeed -= item.test7;
        PlayerMovement.Instance.defense += (-(item.defense));
        PlayerMovement.Instance.critBonus += (-(item.critBonus));
        PlayerMovement.Instance.minDamage += (-(item.minDamage));
        PlayerMovement.Instance.maxDamage += (-(item.maxDamage));
        PlayerMovement.Instance.attackDamage += (-(item.attackDamage));
        PlayerMovement.Instance.basicCooldown += item.test8;
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
        if (item.itemType == Item.ItemType.Amulet)
        {
            PlayerMovement.Instance.Amulet1 = false;
        }
        if (item.itemType == Item.ItemType.Staff)
        {
            PlayerMovement.Instance.Staff1 = false;
        }
        if (item.itemType == Item.ItemType.Boots)
        {
            PlayerMovement.Instance.Boots1 = false;
        }
        if (item.itemType == Item.ItemType.Gloves)
        {
            PlayerMovement.Instance.Gloves1 = false;
        }
        if (item.itemType == Item.ItemType.Head)
        {
            PlayerMovement.Instance.Head1 = false;
        }
        GameObject.Find("Player Stats").GetComponent<PlayerStats>().SetPlayerStats();
    }

}
