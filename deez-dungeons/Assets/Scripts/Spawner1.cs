using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyType;
    [SerializeField]
    private int enemyAmount;

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
                StartCoroutine(spawnEnemy(enemyType));
            }
        }
    }

    public IEnumerator spawnEnemy(GameObject enemy)
    {
        while (enemyAmount >= 1)
        {
            Instantiate(enemy, GeneratedPosition(), Quaternion.identity);
            enemyAmount--;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
