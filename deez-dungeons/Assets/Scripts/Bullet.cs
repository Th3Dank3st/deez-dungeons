using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float range;
    public float damage;
    //public GameObject hitEffect;
    //private Rigidbody2D rb;
    //public float slowDuration;
    private GameObject enemy;
    public float explosionDuration;
    public GameObject hitEffect;
    //private bool alreadySlowed = false;
    //public float mustBeLowerThanSlowDuration;


    //public float knockback;

    void Start()
    {

        Destroy(this.gameObject, range);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other != null)
            {
                other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-damage);
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