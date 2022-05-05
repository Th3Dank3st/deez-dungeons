using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockAoeExplosion : MonoBehaviour
{
    public float damage;
    private bool alreadyHit = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!alreadyHit)
            {
                other.gameObject.GetComponent<PlayerMovement>().UpdateHealth(-damage);
                alreadyHit = true;
            }
            
        }
    }
}
