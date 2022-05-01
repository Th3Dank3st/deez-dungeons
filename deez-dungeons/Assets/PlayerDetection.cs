using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{



    private void Start()
    {
        gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().enabled = false;          //changed lunar slash to luanr slash layer, changed the trigger collider for aggro on bat to lunar slash layer, need to make lunar slash collider not detect the aggro trigger collider
        gameObject.GetComponentInParent<PathEnemyShooting>().enabled = false;
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            {
                gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().enabled = true;
                gameObject.GetComponentInParent<PathEnemyShooting>().enabled = true;
            }

        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Pathfinding.AIDestinationSetter>().enabled = false;
        gameObject.GetComponent<PathEnemyShooting>().enabled = false;
    }*/
}
