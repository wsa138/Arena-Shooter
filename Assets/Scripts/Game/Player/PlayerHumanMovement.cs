using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHumanMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        SetMovementvelocity();

        FlipSprite();

    }

    private void SetMovementvelocity()
    {
        // Calculate movement by smoothing it over time
        _smoothedMovementInput = Vector2.SmoothDamp(
            // Current value we want to add to Player object
            _smoothedMovementInput,
            // Value to reach
            _movementInput,
            // Current velocity, modified by function as it moves towards target value
            ref _movementInputSmoothVelocity,
            // Over time:
            0.1f);

        // Use smoothed movement input times speed value to set position
        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(-_rigidbody.velocity.x), 1f);
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

}
