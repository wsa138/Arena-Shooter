using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBossBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Test");
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the object this script is attached to
        }
    }
}
