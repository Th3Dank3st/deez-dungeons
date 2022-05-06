using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float explosionDuration;
    public GameObject hitEffect;
    public float range;
    [SerializeField] private float damage = 10f;

    void Start()
    {
        Destroy(this.gameObject, range);
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player") 
        {
            other.gameObject.GetComponent<PlayerMovement>().UpdateHealth(-damage);
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