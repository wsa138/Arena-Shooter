using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipShoot : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;

    [SerializeField] private float _laserSpeed;

    [SerializeField] private Transform _gunOffset1;
    [SerializeField] private Transform _gunOffset2;

    [SerializeField] private float _timeBetweenShots;

    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime;
    
    // Update is called once per frame
    void Update()
    {
        // _fireSingle basically saves on fire if shoot was clicked before the timer of the first bullet expired. Then set back to false;
        if (_fireContinuously || _fireSingle)
        {
            // Calculate amount of time passed since last laser1 fired.
            float timeSinceLastFire = Time.time - _lastFireTime;
            // If enough time has passed, fire the laser1.
            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireLaser();
            // Set time that last laser1 fired.
            _lastFireTime = Time.time;
            // Set the other fire trigger to false.
            _fireSingle = false;
            }
        }
    }

    // Fire two lasers, one from each gunOffset position.
    private void FireLaser()
    {
        // Bullet spawns in with Laser Prefab, at the GunOffset position, facing in the correct direction.
        GameObject laser1 = Instantiate(_laserPrefab, _gunOffset1.position, transform.rotation);
        GameObject laser2 = Instantiate(_laserPrefab, _gunOffset2.position, transform.rotation);
        // Get the rigidbody1 of the laser1 prefab.
        Rigidbody2D rigidbody1 = laser1.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbody2 = laser2.GetComponent<Rigidbody2D>();
        // Set the velocity of the laser1's rigidbody1 when it spawns.
        rigidbody1.velocity = _laserSpeed * transform.up;
        rigidbody2.velocity = _laserSpeed * transform.up;
    }

    // Input system function.
    private void OnFire(InputValue inputValue)
    {
        // Set variable to true when fire is pressed.
        _fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
    }
}
