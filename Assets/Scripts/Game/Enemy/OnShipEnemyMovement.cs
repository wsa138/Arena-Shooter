using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShipEnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;

    private OnShipEnemyAwarenessController enemyAwarenessController;

    private void Awake()
    {
        enemyAwarenessController = GetComponent<OnShipEnemyAwarenessController>();
    }
    private void Update()
    {
        if (enemyAwarenessController.AwareOfPlayer)
        {
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
        }
        
    }
}
