using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnFromBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnInterval = 2f;

    private void Start()
    {
        // Start the coroutine for spawning enemies
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Spawn the enemy prefab at the position of the GameObject to which this script is attached
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}

