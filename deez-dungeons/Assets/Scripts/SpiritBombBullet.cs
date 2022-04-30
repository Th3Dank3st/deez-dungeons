using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBombBullet : MonoBehaviour
{

    public float duration, damage;
    public GameObject hitEffect;
    public float DeathTime;


    void Start()
    {
        StartCoroutine(waiter());
        

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Enemy")
        {
            collisionGameObject.GetComponent<EnemyHealth>().UpdateHealth(-damage);
        }

        if (collisionGameObject.tag != "Enemy")
        {
            if (collisionGameObject/*.GetComponent<HealthScript>()*/ != null)
            {
                //collisionGameObject.GetComponent<HealthScript>().TakeDamage(damage);

                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, duration);
                Destroy(gameObject);
            }

            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, duration);
            //Destroy(gameObject);
        }
        else if (collisionGameObject.tag != "Wall")
        {
            if (collisionGameObject != null)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, duration);
                Destroy(gameObject);
            }
        }
    }

    public IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, duration);
        Destroy(gameObject);
    }

}