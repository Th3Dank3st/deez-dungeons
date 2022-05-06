using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyType;
    [SerializeField]
    private int enemyAmount;
    [SerializeField]
    private GameObject enemyType2;
    [SerializeField]
    private int enemyAmount2;


    public Transform spawner;
    public float spawnRange = 5f;

    Vector3 GeneratedPosition()
    {

        return (Vector2)spawner.position + spawnRange * Random.insideUnitCircle;
    }

    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            {
                StartCoroutine(spawnEnemy(enemyType, enemyType2));
            }
        }
    }

    public IEnumerator spawnEnemy(GameObject enemy, GameObject enemy2)
    {
        while (enemyAmount >= 1)
        {
            Instantiate(enemy, GeneratedPosition(), Quaternion.identity);
            enemyAmount--;
            yield return new WaitForSeconds(1f);
        }

        while (enemyAmount2 >= 1)
        {
            Instantiate(enemy2, GeneratedPosition(), Quaternion.identity);
            enemyAmount2--;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
