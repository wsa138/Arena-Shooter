using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShipEnemyAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField] private float _HumanAwarenessDistance;

    // Where the human player is
    private Transform _humanLocation;

    private void Awake()
    {
        _humanLocation = FindObjectOfType<GunArmMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyDistanceToPlayer = _humanLocation.position - transform.position;
        DirectionToPlayer = enemyDistanceToPlayer.normalized;

        if (enemyDistanceToPlayer.magnitude <= _HumanAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
