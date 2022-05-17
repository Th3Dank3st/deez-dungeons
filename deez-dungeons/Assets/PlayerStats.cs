using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text level;
    public Text text0;
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
    public Text text12;
    //public Text text13;
    

    public void SetPlayerStats()
    {
        String string0 = PlayerMovement.Instance.maxHealth.ToString();
        String string1 = PlayerMovement.Instance.regenAmount.ToString();
        String string2 = PlayerMovement.Instance.maxMana.ToString();
        String string3 = PlayerMovement.Instance.manaRegenAmount.ToString();
        String string4 = PlayerMovement.Instance.defense.ToString();
        String string5 = PlayerMovement.Instance.attackDamage.ToString();
        String string6 = PlayerMovement.Instance.critBonus.ToString();
        String string7 = PlayerMovement.Instance.minDamage.ToString();
        String string8 = PlayerMovement.Instance.maxDamage.ToString();
        String string9 = PlayerMovement.Instance.basicCooldown.ToString();
        String string10 = PlayerMovement.Instance.spellDamage.ToString();
        String string11 = PlayerMovement.Instance.cooldown.ToString();
        String string12 = PlayerMovement.Instance.moveSpeed.ToString();

        if (string0.Length > 4)
        {
            string0 = string0.Substring(0, 4);
        }
        if (string1.Length > 4)
        {
            string1 = string1.Substring(0, 4);
        }
        if (string2.Length > 4)
        {
            string2 = string2.Substring(0, 4);
        }
        if (string3.Length > 4)
        {
            string3 = string3.Substring(0, 4);
        }
        if (string4.Length > 4)
        {
            string4 = string4.Substring(0, 4);
        }
        if (string5.Length > 4)
        {
            string5 = string5.Substring(0, 4);
        }
        if (string6.Length > 4)
        {
            string6 = string6.Substring(0, 4);
        }
        if (string7.Length > 4)
        {
            string7 = string7.Substring(0, 4);
        }
        if (string8.Length > 4)
        {
            string8 = string8.Substring(0, 4);
        }
        if (string9.Length > 4)
        {
            string9 = string9.Substring(0, 4);
        }
        if (string10.Length > 4)
        {
            string10 = string10.Substring(0, 4);
        }
        if (string11.Length > 4)
        {
            string11 = string11.Substring(0, 4);
        }
        if (string12.Length > 4)
        {
            string12 = string12.Substring(0, 4);
        }

        level.text = ("Lv.  " + PlayerMovement.Instance.levelText.text);
        text0.text = string0;
        text1.text = string1;
        text2.text = string2;
        text3.text = string3;
        text4.text = string4;
        text5.text = string5;
        text6.text = string6;
        text7.text = string7;
        text8.text = string8;
        text9.text = string9;
        text10.text = string10;
        text11.text = string11;
        text12.text = string12;










    }

}
