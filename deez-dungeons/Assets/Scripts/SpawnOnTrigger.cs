using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private float swarmerInterval;
    [SerializeField]
    private float eliteInterval;

    public Transform spawner;
    public GameObject spawnerobject;
    public float spawnRange = 5f;

    public float spawnerActiveTime;





    


    Vector3 GeneratedPosition()
    {

        return (Vector2)spawner.position + spawnRange * Random.insideUnitCircle;
    }

    //    public void Start()
    //{
            //private float swarmerInterval = (spawnerActiveTime) / (swarmer - 0.01f);
            //private float eliteInterval = (spawnerActiveTime) / (elite - 0.05f);

    //}
private void OnTriggerEnter2D(Collider2D other)
    {
        //float swarmers = (spawnerActiveTime) / (swarmer - 0.02f);
        //float elites = (spawnerActiveTime) / (elite - 0.3f);
        

        if (other.gameObject.tag == "Player")
        {
            {
                //float swarmerInterval = (spawnerActiveTime) / (swarmer - 0.02f);
                //float eliteInterval = (spawnerActiveTime) / (elite - 0.05f);
                StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
                StartCoroutine(spawnEnemy(eliteInterval, bigSwarmerPrefab));
                Destroy(spawnerobject, spawnerActiveTime);
            }
            
        }
        
    }

    public IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, GeneratedPosition(), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
        //add counter to make endless

    }
}
