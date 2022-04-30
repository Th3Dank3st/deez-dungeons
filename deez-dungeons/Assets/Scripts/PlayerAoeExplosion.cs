using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAoeExplosion : MonoBehaviour
{
    //public float speed = 3f;
    //private Transform target;
    public float attackDamage;
    public float attackSpeed;
    private float canAttack;
    //public GameObject hitEffect;
    //public float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;

            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}