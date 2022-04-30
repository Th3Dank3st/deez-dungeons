using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeHeal : MonoBehaviour
{
    private GameObject target;
    public float nextHeal;
    public float healRate;
    public float damage;
    //private GameObject runes;

    private void Start()
    {
        //runes.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (target != null)
        {
            if (Time.time > nextHeal)// if i can shoot (based on healRate+time.time below)
            {
                nextHeal = Time.time + healRate; // defining healRate
                {// i will heal
                    target.GetComponent<PlayerMovement>().UpdateHealth(+damage);
                    //runes.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}
