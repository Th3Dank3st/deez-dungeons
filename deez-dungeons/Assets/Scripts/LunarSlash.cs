using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarSlash : MonoBehaviour
{
    public float range, damage;
    void Start()
    {
        Destroy(this.gameObject, range);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject != null)
            {
                other.GetComponentInParent<EnemyHealth>().UpdateHealth(-damage);
            }
        }
    }
}

   