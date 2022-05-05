using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSummonLookAt : MonoBehaviour
{

    private bool canSee = false;
    private Transform target;
    public class EnemyLookAt : MonoBehaviour
    {


        //private Transform target;
        void Update()
        {
            //target = GameObject.FindGameObjectWithTag("Enemy").transform;
            //if (canSee)
            //{
                //transform.right = target.position - transform.position;
            //}
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            canSee = true;
            target = other.gameObject.GetComponent<Transform>().parent;           
        }
        if (other = null)
        {
            canSee = false;
        }
    }
}
