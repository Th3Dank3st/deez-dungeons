using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroAI : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public float fireRate = 1;
    private float NextFire = 1;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce;
    //private Transform player;


    //these are for the explosion---------remove these 4 lines + the lines commented as explosion on line 70
    public float duration;
    public GameObject hitEffect;
    [SerializeField] private float damage = 10f;



    private void Update()
    {
        if(target != null)//  <--- if i can see the target
        {//i am going to get the info below:
            float step = speed * Time.deltaTime;                                              // where to move
            target.position = Vector2.MoveTowards(transform.position, target.position, step); // where to move



            if (Time.time > NextFire)// if i can shoot (based on FireRate)
            {
                NextFire = Time.time + fireRate; // defining FireRate
                {// i will shoot
                    Shoot();
                }
            }



        }

        //if (target == null)
        //{
        //
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = null;
        }
    }


    //this is the explosion, can replace with a melee attack maybe, or remove for charachters that you don't want to explode.
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            collisionGameObject.GetComponent<PlayerMovement>().UpdateHealth(-damage);
        }

        if (collisionGameObject.tag != "Player")
        {
            if (collisionGameObject/*.GetComponent<PlayerHealth>()*/ != null)
            {
                //collisionGameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);

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


    // our shoot function
void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
