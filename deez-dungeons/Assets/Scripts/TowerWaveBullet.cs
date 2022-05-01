using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWaveBullet : MonoBehaviour
{
    public float range, damage;
    private GameObject enemy;


    void Start()
    {
        Vector3 newRotation = new Vector3(0, 0, -90);
        transform.eulerAngles = newRotation;
        Destroy(this.gameObject, range);
    } 
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        enemy = other.gameObject;
        if (enemy.gameObject.tag == "Player")
        {
            
            other.GetComponent<PlayerMovement>().UpdateHealth(-damage);
        }        
    }
}