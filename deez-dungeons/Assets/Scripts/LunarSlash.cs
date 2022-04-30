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
    //private void Stop(int seconds)
    //{

    //if (waiting)
    //return;
    //StartCoroutine(Wait(seconds));
    //}    
    /*IEnumerator Wait(int seconds)
    {
        var path = enemy.GetComponent<Pathfinding.AIPath>();
        var originalSpeed = path.maxSpeed;
        Debug.Log("originalSpeed1 = " + originalSpeed.ToString());
        path.maxSpeed = 0;
        yield return new WaitForSeconds(seconds);

        Debug.Log("originalSpeed2 = " + originalSpeed.ToString());
        path.maxSpeed = originalSpeed;
        Debug.Log("originalSpeed3 = " + originalSpeed.ToString());

    }*/
}

   