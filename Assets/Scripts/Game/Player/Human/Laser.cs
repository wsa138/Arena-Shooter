using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<OnShipEnemyMovement>())
        {
            ScoreManager.score += 10;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.GetComponent<CompositeCollider2D>())
        {
            Destroy(gameObject);
        }
    }
}
