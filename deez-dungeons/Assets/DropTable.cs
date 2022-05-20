
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable : MonoBehaviour
{
    public GameObject[] items;
    public Transform spawnLocation;
    public float droprate;
    private int lengthOfTable;
    private bool dropped = false;
    public void DropItem()
    {
        var lastKnownPos = spawnLocation;
        foreach (GameObject item in items)
        {
            if (item != null)
            {
                lengthOfTable++;
            }
        }
        int drop = Random.Range(1, 100);
        if (!dropped)
        {
            if (drop <= droprate)
            {
                dropped = true;
                //Debug.Log(lengthOfTable);
                Instantiate(items[Random.Range(0, lengthOfTable)], lastKnownPos.position, lastKnownPos.rotation);
            }
        }      
    }
}
