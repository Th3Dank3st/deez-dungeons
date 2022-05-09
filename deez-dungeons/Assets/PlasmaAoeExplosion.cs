using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaAoeExplosion : MonoBehaviour
{
    public float damage = 50f;

    private void Awake()
    {
        damage *= FindObjectOfType<PlayerMovement>().spellDamage;
        Destroy(gameObject, 0.35f);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject != null)
            {
                other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-damage);
            }
        }
    }
}