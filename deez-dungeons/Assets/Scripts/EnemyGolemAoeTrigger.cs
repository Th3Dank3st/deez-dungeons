using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGolemAoeTrigger : MonoBehaviour
{
    //public float speed = 3f;
    //private Transform target;
    public float attackDamage;
    public float attackSpeed;
    private float canAttack;
    public GameObject hitEffect;
    public float duration;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerMovement>().UpdateHealth(-attackDamage);
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, duration);
                canAttack = 0f;
                
            }
            else 
            {
                canAttack += Time.deltaTime;
            }
        }
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;


        }
    }*/
}
