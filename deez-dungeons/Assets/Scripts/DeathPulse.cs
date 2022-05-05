using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPulse : MonoBehaviour
{
    public float damage;
    public float duration = 1;
    private bool alreadyHit;
    void Awake()
    {
        Destroy(this.gameObject, duration);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool alreadyHit = false;
        if (other.gameObject.tag == "Player")
        {
            if (!alreadyHit)
            {
                other.gameObject.GetComponent<PlayerMovement>().UpdateHealth(-damage);
                alreadyHit = true;
            }
        }


    }
}
