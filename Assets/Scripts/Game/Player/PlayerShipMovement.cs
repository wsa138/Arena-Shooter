using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidBody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInpuit();
    }

    private void SetPlayerVelocity()
    {
        // Smooth movement so it doesn't start and stop suddenly
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            .2f
            );

        // Set player velocity
        _rigidBody.velocity = _smoothedMovementInput * _speed;
    }

    private void RotateInDirectionOfInpuit()
    {
        if (_movementInput != Vector2.zero)
        {
            // Get target
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            // Rotate towards target
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidBody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        // Capture movement input whenever it changes
        _movementInput = inputValue.Get<Vector2>();
    }

}
