using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaAoeExplosion : MonoBehaviour
{
    public float damage = 50f;
    private bool alreadyhit = false;

    private void Awake()
    {
        damage *= FindObjectOfType<PlayerMovement>().spellDamage;
        Destroy(gameObject, 0.35f);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject != null && alreadyhit == false)
            {
                other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-damage);
                alreadyhit = true;
            }
        }
    }
}