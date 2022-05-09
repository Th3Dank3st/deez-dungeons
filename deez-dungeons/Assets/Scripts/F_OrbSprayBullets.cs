using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_OrbSprayBullets : MonoBehaviour
{
    public float range;
    public float damage;
    //public GameObject hitEffect;
    //private Rigidbody2D rb;
    //public float slowDuration;
    private GameObject enemy;
    //private bool alreadySlowed = false;
    //public float mustBeLowerThanSlowDuration;
    

    //public float knockback;

    void Start()
    {
        //Destroy(gameObject.GetComponent<SpriteRenderer>(), 0.6f);
        //Destroy(gameObject.GetComponent<Collider2D>(), 0.6f);
        //Destroy(gameObject.GetComponent<TrailRenderer>(), 0.6f);
        Destroy(this.gameObject, range);
    }
    //void Update()
    //{
    // if (rooted)
    // {
    //    Debug.Log("canMove = false");
    //     enemy.GetComponent<Pathfinding.AIPath>().canMove = false;
    // }

    // if (!rooted)
    // {
    //     enemy.GetComponent<Pathfinding.AIPath>().canMove = true;
    //     Debug.Log("canMove = True");
    // }

    //}

    private void OnCollisionEnter2D(Collision2D other)    
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other != null)
            {
                other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-damage);
                Destroy(this.gameObject);
            }
         

            
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //gameObject.GetComponent<Collider2D>().enabled = false;
            //gameObject.GetComponent<TrailRenderer>().enabled = false;
        }

        if (other.gameObject.tag == "Wall")
        {
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, effectDuration);
            Destroy(this.gameObject);
            
        }
    }


    //private void Stop(int seconds)
    //{

    //if (waiting)
    //return;
    //StartCoroutine(Wait(seconds));
    //}


    /*IEnumerator Slow(float seconds)
    {
        
        var path = enemy.GetComponent<Pathfinding.AIPath>();
        var originalSpeed = path.maxSpeed;
        Debug.Log(alreadySlowed + "1");
        path.maxSpeed *= 0.65f;
        alreadySlowed = true;
        Debug.Log("seconds1 = " + seconds.ToString());
        yield return new WaitForSeconds(seconds);
        
        
        
        path.maxSpeed = originalSpeed;
        alreadySlowed = false;
        Debug.Log(alreadySlowed + "3");
        yield break;
        
    }*/



    
}
