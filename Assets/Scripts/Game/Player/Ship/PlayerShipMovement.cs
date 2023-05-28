using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _screenBorder;

    private Rigidbody2D _rigidBody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;
    

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
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
        PreventPlayerGoaingOffScreen();
    }

    private void PreventPlayerGoaingOffScreen()
    {
        // Get the player's position on screen.
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        // Prevent player from walking out of the screen on x axis.
        if ((screenPosition.x < _screenBorder && _rigidBody.velocity.x < 0) || (screenPosition.x > _camera.pixelWidth - _screenBorder && _rigidBody.velocity.x > 0))
        {
            _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        }

        // Prevent player from walking out of the screen on y axis.
        if ((screenPosition.y < _screenBorder && _rigidBody.velocity.y < 0) || (screenPosition.y > _camera.pixelHeight - _screenBorder && _rigidBody.velocity.y > 0))
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
        }
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
