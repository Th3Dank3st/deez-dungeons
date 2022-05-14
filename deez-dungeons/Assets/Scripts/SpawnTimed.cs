using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimed : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {            
                if (spawnerActiveTime > 0)
                {
                    StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
                    StartCoroutine(spawnEnemy(eliteInterval, bigSwarmerPrefab));
                }
        }
    }

    public IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, GeneratedPosition(), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
        spawnerActiveTime -= interval;

        //add counter to make endless

    }
}
