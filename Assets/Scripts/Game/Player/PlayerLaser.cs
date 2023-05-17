using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
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
}
