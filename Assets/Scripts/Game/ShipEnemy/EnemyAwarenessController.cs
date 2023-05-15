using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwarenessController : MonoBehaviour
{ 
    // "get; private set;" allows other classes to read value but only this class to set it.
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField] private float _enemyAwarenessDistance;

    private Transform _player;


    private void Awake()
    {
        // Find the player's transform, searches all game objects for particular component(PlayerShipMovement component in this case).
        _player = FindObjectOfType<PlayerShipMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Find how far away and what direction player is to this enemy.
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        // Don't need magnitude of vector, just direction so we normalize the vector(Keeps direction, sets Mag to 1).
        DirectionToPlayer = enemyToPlayerVector.normalized;

        // Check if player is close enough. Mag of vector will give distance to player, then check is <= to enemyAwarenessDistance. 
        if (enemyToPlayerVector.magnitude <= _enemyAwarenessDistance)
        {
            AwareOfPlayer = true;
        } else
        {
            AwareOfPlayer = false;
        }
    }
}
