using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    bool facingLeft = true;
    private Transform armTransform;
    private float currentPositionX;

    Vector2 movement;
    Vector3 mousePos;

    // Trigger movement with Update
    private void Update()
    {
        GetInput();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Actually move player with Fixed Update
    private void FixedUpdate()
    {
        Move();
        FlipSprite();
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

    private void FlipSprite()
    {
        // Get the gameOjbect x position
        currentPositionX = transform.position.x;

        if (mousePos.x < currentPositionX && facingLeft == false)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            facingLeft = true;
        }

        if (mousePos.x > currentPositionX && facingLeft == true)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            facingLeft = false;
        }
    }
}