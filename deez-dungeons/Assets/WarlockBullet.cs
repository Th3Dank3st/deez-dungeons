using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockBullet : MonoBehaviour
{
    //public float explosionDuration;
    //public GameObject hitEffect;
    public float range;
    [SerializeField] private float damage = 10f;

    void Start()
    {
        Destroy(this.gameObject, range);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            collisionGameObject.GetComponent<PlayerMovement>().UpdateHealth(-damage);
            Destroy(this.gameObject);
        }

        //if (collisionGameObject.tag != "Player")
        {
            if (collisionGameObject/*.GetComponent<PlayerHealth>()*/ != null)
            {
                //collisionGameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);

                //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                // Destroy(effect, explosionDuration);

                // }

                //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                //Destroy(effect, duration);
                //Destroy(gameObject);
            }
            else if (collisionGameObject.tag != "Wall")
            {
                if (collisionGameObject != null)
                {
                    // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                    // Destroy(effect, explosionDuration);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
