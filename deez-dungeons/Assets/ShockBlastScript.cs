using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBlastScript : MonoBehaviour
{
    public float damage;

    private void Awake()
    {
        damage *= FindObjectOfType<PlayerMovement>().spellDamage;
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

