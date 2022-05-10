using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShutTrigger : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door1.SetActive(true);
            door2.SetActive(true);
        }
    }
}
