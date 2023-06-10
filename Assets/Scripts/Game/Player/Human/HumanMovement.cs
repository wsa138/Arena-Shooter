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
    Vector3 newArmScale;

    private void Start()
    {
        armTransform = transform.Find("Arm");
    }

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
            newArmScale.x = 1f;
            newArmScale.y = 1f;
            armTransform.localScale = newArmScale;
        }

        if (mousePos.x > currentPositionX && facingLeft == true)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            facingLeft = false;
            newArmScale.x = -1f;
            newArmScale.y = -1f;
            armTransform.localScale = newArmScale;
        }
    }
}