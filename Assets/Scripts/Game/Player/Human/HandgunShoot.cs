using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandgunShoot : MonoBehaviour
{
    [SerializeField] private Transform gunOffset;
    [SerializeField] private GameObject handgunBullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeBetweenShots;

    private bool _fireContinuously;
    private float _lastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_fireContinuously)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= timeBetweenShots)
            {
                FireBullet();

                _lastFireTime = Time.time;
            }
        }        
    }

    private void FireBullet()
    {
        // Spawn bullet prefab at gun offset position, facing the correct direction.
        GameObject bullet = Instantiate(handgunBullet, gunOffset.position, transform.rotation);
        Vector3 correctedRotation = bullet.transform.eulerAngles;
        correctedRotation.z += 90f;
        bullet.transform.rotation = Quaternion.Euler(correctedRotation);

        // Get the rigidbody bullet prefab.
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        // Set the velocity of bullet when it spawns.
        bulletRigidBody.velocity = bulletSpeed * -transform.right;
    }

    private void OnFire(InputValue inputValue)
    {
        // Set variable to true when fire is pressed.
        _fireContinuously = inputValue.isPressed;
    }
}
