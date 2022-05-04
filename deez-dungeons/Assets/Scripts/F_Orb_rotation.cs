using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Orb_rotation : MonoBehaviour
{
    public float range;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce;
    public float rotationSpeed;
    //public float spraySpeed;
    private float bulletCoolCounter;
    public float bulletRateOfFire;



    void Start()
    {
        Destroy(this.gameObject, range);


    }
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime, Space.Self);
        //StartCoroutine(Spray(range, spraySpeed));
        if (this.gameObject != null)
        {
            if (bulletCoolCounter <= 0)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

                bulletCoolCounter = bulletRateOfFire;
            }
        }

        if (bulletCoolCounter > 0)
        {
            bulletCoolCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}

   /* IEnumerator Spray(float seconds)
    {
        bool spinning = true;

        float counter = mustEqualRange;
        
        while (counter > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(seconds);
            counter--;

            if(counter <= 0)
            {
                spinning = false;
                yield break;
            }



        }

    }*/





    /*IEnumerator Spray(float counter, float SS)
    {
        while (counter > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(SS);
            counter -= SS;

            if (counter <= 0)
            {
                Destroy(this.gameObject);
                yield break;
            }
        }
    }
}*/
