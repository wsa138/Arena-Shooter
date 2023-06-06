using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] GameObject _enemyPrefab; // Reference enemy prefab
    [SerializeField] float _spawnIntervalMin = 2f; // Min interval between enemy spawns
    [SerializeField] float _spawnIntervalMax = 3f; // Max interval
    private float _timeUntilSpawn;
    [SerializeField] private float waveTwoScore;

    private void Awake()
    {
        // Set time until spawn when scene first starts.
        SetTimeUntilSpawn();
    }

    private void Update()
    {
        // Decrease spawn interval if score is above certain number.
        if (ScoreManager.score > waveTwoScore)
        {
            _spawnIntervalMax = 2.1f;
        }

        // Reduce time until spawn by amount of time that has passed in a frame.
        _timeUntilSpawn -= Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (_timeUntilSpawn <= 0)
        {
            CreateEnemy();
            SetTimeUntilSpawn(); // Reset timer
        }
    }

    private void CreateEnemy()
    {
        // Instantiate an enemy at the spawn point
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_spawnIntervalMin, _spawnIntervalMax);
    }
}
