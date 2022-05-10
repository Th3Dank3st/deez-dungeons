using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Item itemz;
    private Text pickedUpItemText;
    private bool itemtxt = false;
    private bool itemtxt2 = false;

    public void OnCollisionEnter2D(Collision2D other)      // the original line of code for this function is Pickup(); only
    {
        if(other.gameObject.tag == "Player")
        {
            pickedUpItemText = FindObjectOfType<Text>();
            if (pickedUpItemText.name == "ItemFoundText")
            {
                string itemname = itemz.itemName;
                pickedUpItemText.text = (itemname + " has been found!");
                Pickup();
            }            
        }
    }

    void Pickup()
    {                   
        InventoryManager.Instance.Add(itemz);
        Destroy(gameObject);
    }
}