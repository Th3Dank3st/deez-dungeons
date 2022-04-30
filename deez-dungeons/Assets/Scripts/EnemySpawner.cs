using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject elitePrefab;
    [SerializeField]
    private GameObject swarmerPrefab2;
    [SerializeField]
    private GameObject elitePrefab2;

    [SerializeField]
    private float swarmerInterval;
    [SerializeField]
    private float eliteInterval;
    [SerializeField]
    private float swarmerInt2;
    [SerializeField]
    private float eliteInt2;

    public Transform spawner;
    public GameObject spawnerobject;
    public float spawnRange = 5f;
    public float spawnerActiveTime = 1f;








    Vector3 GeneratedPosition()
    {
        //int x, y, z;
        //x = Random.Range(5, 10);
        //y = Random.Range(5, 10);
        //z = 0;
        // return new Vector3(x, y, z);
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
                StartCoroutine(spawnEnemy(eliteInterval, elitePrefab));
                StartCoroutine(spawnEnemy(swarmerInt2, swarmerPrefab2));
                StartCoroutine(spawnEnemy(eliteInt2, elitePrefab2));
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