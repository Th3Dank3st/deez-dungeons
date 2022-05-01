using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarSlash : MonoBehaviour
{
    public float range, damage;
    //public float  effectDuration;
    //public GameObject hitEffect;
    //public int rootDuration;
    private GameObject enemy;    

    void Start()
    {
        Destroy(this.gameObject, range);
    }





    public void OnTriggerEnter2D(Collider2D other)
    {
        enemy = other.gameObject;
        if (enemy.gameObject.tag == "Enemy")
        {            
            //StartCoroutine(Wait(rootDuration));
            other.GetComponent<EnemyHealth>().UpdateHealth(-damage);            
        }
       // if (enemy.gameObject.tag == "Wall")
       // {
           // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
           // Destroy(effect, effectDuration);
           // Destroy(this.gameObject);
        //}
    }
   
}

   