using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private EnemyAwarenessController _enemyAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyAwarenessController = GetComponent<EnemyAwarenessController>();
        _targetDirection = transform.up;
    }

    private void FixedUpdate()
    {
        // Set target direction
        UpdateTargetDirection();
        // Rotate to target
        RotateTowardsTarget();
        // Move enemy in that direction
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;

        if (_changeDirectionCooldown <= 0)
        {
            // Create random angle
            float angleChange = Random.Range(-90f, 90f);
            // Create rotation. AngleAxis creates rotation that rotates a number degrees around an axis. Rotate around forward which is towards the screen.
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            // New target direction = rotation * new direction.
            _targetDirection = rotation * _targetDirection;
            // Set cooldown
            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (_enemyAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _enemyAwarenessController.DirectionToPlayer;
        }
    }

    private void RotateTowardsTarget()
    {
        // Get target
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        // Rotate towards target
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = transform.up * _speed;               
    }

}
