using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public GameObject patrolPointPrefab;
    public Transform enemyTransform;
    public float patrolRange;
    private Transform patrolTarget1;
    private Transform patrolTarget2;
    private bool canSeePlayer = false;
    private bool isWalking = false; //this is for the enum
    private bool alreadyPatroling = false;
    public bool patrolUnit = false;
    private GameObject patrolPoint1;
    private GameObject patrolPoint2;
    //private bool walkingToTarget1 = false;
    //private bool walkingToTarget2 = false;
    //private bool isAtTarget1 = false;
    //private bool isAtTarget2 = false;
    //public float patrolRange = 5f;

    //public bool patrolEnemy = false;


    private void Start()
    {
        //gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().enabled = false;          //changed lunar slash to luanr slash layer, changed the trigger collider for aggro on bat to lunar slash layer, need to make lunar slash collider not detect the aggro trigger collider
        gameObject.GetComponentInParent<PathEnemyShooting>().enabled = false;
        //GameObject patrolPoint1 = Instantiate(patrolPointPrefab, GeneratedPosition(), Quaternion.identity);
        //GameObject patrolPoint2 = Instantiate(patrolPointPrefab, GeneratedPosition(), Quaternion.identity);

        //patrolTarget1 = patrolPoint1.gameObject.GetComponent<Transform>();
        //patrolTarget2 = patrolPoint2.gameObject.GetComponent<Transform>();
        gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = patrolTarget1;
        // }
        //patrolTarget1 = Instantiate(EnemyPosition, GeneratedPosition(), Quaternion.identity);
        // patrolTarget2 = Instantiate(EnemyPosition, GeneratedPosition(), Quaternion.identity);
    }
    //generating random targets
    Vector3 GeneratedPosition()
    {

        return (Vector2)enemyTransform.position + patrolRange * Random.insideUnitCircle;
    }

    private void Update()
    {
        if (patrolUnit)
        {
            if (!canSeePlayer && !alreadyPatroling)
            {
                Debug.Log("StartingCoroutine");
                StartCoroutine(PatrolPath());
            }
        }

        
        







        /*if (patrolEnemy && !canSeePlayer && !isAtTarget1 && !walkingToTarget1 && !walkingToTarget2)
        {
            StartCoroutine(PatrolToTarget1(patrolTarget1));
        }

        if (patrolEnemy && !canSeePlayer && isAtTarget1 && !walkingToTarget1 && !walkingToTarget2)
        {
            StartCoroutine(PatrolToTarget2(patrolTarget2));
        }*/
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            {
                // get player location
                Transform transform = other.gameObject.GetComponent<Transform>();
                canSeePlayer = true;

                //move to player
                gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = transform;                         //                 target =                      //other.gameObject.transform;
                //shoot at player
                gameObject.GetComponentInParent<PathEnemyShooting>().enabled = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canSeePlayer = false;
            gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = patrolTarget1;
            gameObject.GetComponentInParent<PathEnemyShooting>().enabled = false;
        }
    }


    // patrol to target 1
    public IEnumerator PatrolPath()
    {
        
        alreadyPatroling = true;
        Debug.Log("Starting patrol Routine to target 1");
        int v = 15;
        while (v > 0)
        {
            if (!isWalking)
            {
                Debug.Log("Walking to target1");
                isWalking = true;
                patrolPoint1 = Instantiate(patrolPointPrefab, GeneratedPosition(), Quaternion.identity);
                patrolTarget1 = patrolPoint1.gameObject.GetComponent<Transform>();
                gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = patrolTarget1;
            }
            v--;
            yield return new WaitForSeconds(1);
        }
        
        isWalking = false;
        Debug.Log("Ending patrol routine 1 and starting patrol routine 2!");
        Destroy(patrolPoint1);
        int y = 15;
        while (y > 0)
        {
            if (!isWalking)
            {
                isWalking = true;
                GameObject patrolPoint2 = Instantiate(patrolPointPrefab, GeneratedPosition(), Quaternion.identity);
                patrolTarget2 = patrolPoint2.gameObject.GetComponent<Transform>();
                gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = patrolTarget2;
                Debug.Log("Walking to target2");
            }
            v--;
            yield return new WaitForSeconds(1);
        }
        isWalking = false;
        alreadyPatroling = false;
        Destroy(patrolPoint2);
        Debug.Log("done with patrol routine");
    }








    //public IEnumerator PatrolToTarget1(Transform target1)
    //{
      //  while (!canSeePlayer)
       // {
        //    if (!walkingToTarget2 && !walkingToTarget1)
         //   {
           //     walkingToTarget1 = true;
          //      gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = target1;
           //     yield return new WaitForSeconds(15);
           // }
          //  if (walkingToTarget1)
          //  {
          //      isAtTarget1 = true;
          //      walkingToTarget1 = false;
          //      yield break;
         //   }          
       // }
       
   // }

    /*public IEnumerator PatrolToTarget2(Transform target2)
    {
        while (!canSeePlayer)
        {
            if (!walkingToTarget1 && !walkingToTarget2)
            {
                
                walkingToTarget2 = true;
                isAtTarget1 = false;
                gameObject.GetComponentInParent<Pathfinding.AIDestinationSetter>().target = target2;
                yield return new WaitForSeconds(15);
            }
            if (walkingToTarget2)
            {                
                walkingToTarget2 = false;
                yield break;
            }
        }
    }*/


}
