        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

public class EnemyTelegraphAttack : MonoBehaviour
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
    public GameObject Attack1;
    private GameObject oldTele;
    public Collider2D trigger;



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
            if(trigger.IsTouching(other))
            playerInRange = true;
            player = other.gameObject.transform;
            playerPos = new Vector2(player.position.x, player.position.y);            
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
        float i = 1;
        while (i > 0)
        {
            if(!Attacking)
            {
                playerPos = new Vector2(player.position.x, player.position.y);
                Attacking = true;
                //set animation trigger
                m_animator.SetTrigger("Spellcast");
                GameObject newTele = Instantiate(Tele1, playerPos, Quaternion.identity);
                playerLastPos = playerPos;
                oldTele = newTele;
            }

            yield return new WaitForSeconds(1f);
            i--;
        }
        
        Debug.Log("Attack Casted");
        GameObject newAttack = Instantiate(Attack1, playerLastPos, Quaternion.identity);
        Destroy(oldTele, 1f);
        Destroy (newAttack, 1f);
        Attacking = false;
    }
}


