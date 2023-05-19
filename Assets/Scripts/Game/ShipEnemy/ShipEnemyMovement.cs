using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _screenBorder;

    private Rigidbody2D _rigidbody;
    private EnemyAwarenessController _enemyAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;
    private Camera _camera;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyAwarenessController = GetComponent<EnemyAwarenessController>();
        _targetDirection = transform.up;
        _camera = Camera.main;
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
        HandleEnemyOffScreen();
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

    private void HandleEnemyOffScreen()
    {
        // Get the player's position on screen.
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        // If enemy has gone off screen, and target direction is still to that direction(Left Right), change it.
        if ((screenPosition.x < _screenBorder && _targetDirection.x < 0) || (screenPosition.x > _camera.pixelWidth - _screenBorder && _targetDirection.x > 0))
        {
            _targetDirection = new Vector2(-_targetDirection.x, _targetDirection.y);
        }

        // If enemy has gone off screen, and target direction is still to that direction(Up Down), change it.
        if ((screenPosition.y < _screenBorder && _targetDirection.y < 0) || (screenPosition.y > _camera.pixelHeight - _screenBorder && _targetDirection.y > 0))
        {
            _targetDirection = new Vector2(_targetDirection.x, -_targetDirection.y);
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
