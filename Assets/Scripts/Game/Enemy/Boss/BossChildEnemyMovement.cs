using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChildEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private string targetTag = "Player";

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float rotateSpeed = 10f;

    private Transform target;

    private void Start()
    {
        // Find the player GameObject with the specified tag
        GameObject player = GameObject.FindGameObjectWithTag(targetTag);
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player GameObject not found with tag: " + targetTag);
        }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    
}


