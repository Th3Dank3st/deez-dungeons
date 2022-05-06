using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemLazerAttack : MonoBehaviour
{
    //public Transform firePoint;
    //public GameObject bulletPrefab;
    public float FireRate = 6.0f;
    public float NextFire = 1.0f;
    //public float bulletForce;
    private bool playerInRange;
    public Animator m_animator;
    private bool Attacking;
    private Transform player;
    Vector2 playerPos;
    Vector2 playerLastPos;
    public GameObject Tele1;
    //public GameObject Attack1;
    //private GameObject oldTele;
    public Collider2D trigger;
    public float bulletForce;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector3 pos;
    private Quaternion rotation;
    private Quaternion rotation90;



    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Time.time > NextFire)
            {
                NextFire = Time.time + FireRate;
                {
                    StartCoroutine(Attack());
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (trigger.IsTouching(other))
                playerInRange = true;
            player = other.gameObject.transform;
            //playerPos = new Vector2(player.position.x, player.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    IEnumerator Attack()
    {
        pos = firePoint.position;
        rotation = firePoint.rotation;

       


        float i = 1;
        while (i > 0)
        {
            if (!Attacking)
            {
                gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = gameObject.GetComponentInParent<Transform>();
                playerPos = new Vector2(player.position.x, player.position.y);
                Attacking = true;
                //set animation trigger
                m_animator.SetTrigger("Ability");
                GameObject bullet = Instantiate(Tele1, pos, rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(1f);
            i--;
        }
        //Debug.Log("Attack Casted");
        Shoot(rotation);
        gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = player;
        Attacking = false;
    }

    void Shoot(Quaternion rot)
    {

        Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
        GameObject bullet = Instantiate(bulletPrefab, pos, rot * spawnRotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}