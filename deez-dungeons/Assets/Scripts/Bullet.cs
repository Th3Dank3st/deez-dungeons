using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float range;
    public float damage;
    public float minDamage;
    public float maxDamage;
    public float explosionDuration;
    private float resultDamage;
    public GameObject hitEffect;
    public float critchance;

    void Awake()
    {
        if (gameObject.name == "Player Basic Bullet Trail")
        {
            
            minDamage = (damage * .5f) + PlayerMovement.Instance.minDamage;
            maxDamage = (damage * 1.35f) + PlayerMovement.Instance.maxDamage;
            resultDamage = Random.Range(minDamage, maxDamage);
            critchance = Random.Range(1, 100);
            if (critchance <= 5)
            {
                resultDamage *= 1.5f;
            }
        }
        if(gameObject.name != "Player Basic Bullet Trail")
        {
            resultDamage = damage;
        }        
        Destroy(this.gameObject, range);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other != null)
            {
                other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-resultDamage);
            }
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, explosionDuration);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, explosionDuration);
            Destroy(this.gameObject);
        }
    }
}