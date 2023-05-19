using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    // This is a built in method for a trigger collider which our laser has.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object the laser hits has the ShipEnemyMovement component(all enemy ships should)...
        if (collision.GetComponent<ShipEnemyMovement>())
        {
            // Destroy that game object and this bullet.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void DestroyWhenOffScreen()
    {
        // Screen position of bullet
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > _camera.pixelWidth || screenPosition.y < 0 || screenPosition.y > _camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
