using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    public Text text8;
    public Text text9;
    public Text text10;
    public Text text11;

    public void SetPlayerStats()
    {
        text1.text = ("DEFENSE = " + PlayerMovement.Instance.defense.ToString());
        text2.text = ("HEALTH = " + PlayerMovement.Instance.maxHealth.ToString());
        text3.text = ("HP/5 = " + PlayerMovement.Instance.regenAmount.ToString());
        text4.text = ("MOVE SPEED = " + PlayerMovement.Instance.activeMoveSpeed.ToString());
        text5.text = ("ATTACK DAMAGE = " + PlayerMovement.Instance.attackDamage.ToString());
        text6.text = ("ATTACK SPEED = " + PlayerMovement.Instance.basicCooldown.ToString());
        text7.text = ("SPELL DAMAGE = " + PlayerMovement.Instance.spellDamage.ToString());
        text8.text = ("MANA = " + PlayerMovement.Instance.maxMana.ToString());
        text9.text = ("MP/5 = " + PlayerMovement.Instance.manaRegenAmount.ToString());
        text10.text = ("CAST SPEED = " + PlayerMovement.Instance.cooldown.ToString());

    }

}
