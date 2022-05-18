using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float defense;
    public float speed;
    public float attackDamage;
    public float attackSpeed;
    public float spellDamage;
    public float castSpeed;
    public float maxMana;
    public float manaRegen;
    public float maxHealth;
    public float healthRegen;

    public GameObject gmo_toolTip;
    public Text itemDescription;
    public Text itemName;
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
    public Text text13;
    public Text text14;



    void Awake()
    {
        // I added this in case I forgot to set the tooltip object
        if (gmo_toolTip != null)
        {
            gmo_toolTip.SetActive(false);
        }
        GetStats();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Same here
        if (gmo_toolTip != null)
        {
            gmo_toolTip.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // and same here
        if (gmo_toolTip != null)
        {
            gmo_toolTip.SetActive(false);
        }
    }

   
    void GetStats()
    {

        /*//text1.text = ("Defense " + defense.ToString());
        //text2.text = ("Speed " + speed.ToString());
        //text3.text = ("Attack " + attackDamage.ToString());
        //text4.text = ("AttackSPD " + attackSpeed.ToString());
        //text5.text = ("SpellDMG " + spellDamage.ToString());
        //text6.text = ("castSPD " + castSpeed.ToString());
        //text7.text = ("MP " + maxMana.ToString());
        //text8.text = ("MP/5 " + manaRegen.ToString());
        //text9.text = ("HP " + maxHealth.ToString());
        //text10.text = ("HP/5 " + healthRegen.ToString());*/
       
    }
}