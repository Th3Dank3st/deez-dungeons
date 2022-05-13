using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalModeTrigger : MonoBehaviour
{
    public GameObject survivalModeSpawners;




    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            survivalModeSpawners.SetActive(true);
            Destroy(gameObject);
        }
    }
}
