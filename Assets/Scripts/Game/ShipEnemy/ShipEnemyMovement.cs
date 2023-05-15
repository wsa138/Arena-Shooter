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


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyAwarenessController = GetComponent<EnemyAwarenessController>();
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
        if (_enemyAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _enemyAwarenessController.DirectionToPlayer;
        } else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }
        // Get target
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        // Rotate towards target
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
        } else
        {
            _rigidbody.velocity = transform.up * _speed;
        }        
    }

}
