using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    private Transform target;
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.right = target.position - transform.position;
    }
}
