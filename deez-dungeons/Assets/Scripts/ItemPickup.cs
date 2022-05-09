using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item itemz;

    void Pickup()
    {
            InventoryManager.Instance.Add(itemz);
            Destroy(gameObject);
    }
    public void OnCollisionEnter2D()      // the original line of code for this function is Pickup(); only
    {
        Pickup();
    }
}