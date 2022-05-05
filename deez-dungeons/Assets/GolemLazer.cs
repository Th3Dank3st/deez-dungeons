using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemLazer : MonoBehaviour
{
    public float duration, damage;

    void Start()
    {
        Destroy(this.gameObject, duration);
    }





    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //StartCoroutine(Wait(rootDuration));
            other.GetComponent<PlayerMovement>().UpdateHealth(-damage);
        }
        // if (enemy.gameObject.tag == "Wall")
        // {
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, effectDuration);
        // Destroy(this.gameObject);
        //}
    }

}
