using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Trigger movement with Update
    private void Update()
    {
        GetInput();
    }

    // Actually move player with Fixed Update
    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        // Moves player up, down, left right
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}