using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemyPrefab; // Reference enemy prefab
    public Transform spawnPoint; // Reference the spawn point transform
    public float spawnInterval = 2.5f; // Interval between enemy spawns
    [SerializeField] private float waveTwoScore;

    private float spawnTimer = 0f;

    private void Update()
    {
        // Decrease spawn interval if score is above certain number.
        if (ScoreManager.score > waveTwoScore)
        {
            spawnInterval = 1.5f;
        }

        // Increment timer
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (spawnTimer > spawnInterval)
        {
            CreateEnemy();
            spawnTimer = 0f; // Reset timer
        }
    }

    private void CreateEnemy()
    {
        // Instantiate an enemy at the spawn point
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
