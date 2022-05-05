using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPulse : MonoBehaviour
{
    public float damage;
    public float duration = 1;
    void Awake()
    {
        Destroy(this.gameObject, duration);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            collisionGameObject.GetComponent<PlayerMovement>().UpdateHealth(-damage);
        }
    }
}
