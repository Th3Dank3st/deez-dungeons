using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSummon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float FireRate = 1.0f;
    public float NextFire = 1.0f;
    public float bulletForce;



    // Update is called once per frame
    void Update()
    {

        if (Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            {
                Shoot();
            }
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}

