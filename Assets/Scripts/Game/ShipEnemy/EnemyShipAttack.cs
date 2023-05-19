using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAttack : MonoBehaviour
{
    [SerializeField] private float _damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if object we collided with has the PlayerShipMovement component.
        if (collision.gameObject.GetComponent<PlayerShipMovement>())
        {
            // Get the health controller from the collision object.
            var healthController = collision.gameObject.GetComponent<HealthController>();
            // Use the TakeDamage script to damage game object.
            healthController.TakeDamage(_damageAmount);
        }
    }

}
