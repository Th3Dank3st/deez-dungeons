using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable : MonoBehaviour
{
    public GameObject[] items;
    public Transform spawnLocation;
    public float droprate;
    private int lengthOfTable;
    public void DropItem()
    {
        foreach (GameObject item in items)
        {
            if (item != null)
            {
                lengthOfTable++;
            }
        }
        int drop = Random.Range(1, 100);
        if (drop <= droprate)
        {
            Debug.Log(lengthOfTable);
            Instantiate(items[Random.Range(0, lengthOfTable -1)], spawnLocation.position, spawnLocation.rotation);

        }

    }
}
