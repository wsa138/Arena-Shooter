using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Trigger movement with Update
    private void Update()
    {
        GetInput();
    }

    // Actually move player with Fixed Update
    private void FixedUpdate()
    {
        Aim();
    }

    private void ChangeSpriteByDirection()
    {
        // Change the direction that the sprite is faving based on mouse position(Don't use keys, cause then moving left would give left sprite, but could be trying to aim right).

        /* 
         If (mouse position is to the right of the current players position) {
            GetComponent<SpriteRenderer>().sprite = rightFacingSprite;
        } else {
            Load the sprite that is facing left(middle if idle)
        }
         */



        // Once done, need to decouple the mouse position from the sprites z axis rotation.
    }

    private void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Aim()
    {
        // Moves player up, down, left right
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Aim object. Take two vectors and subract them to get one vector that points from one to the other.
        Vector2 lookDir = mousePos - rb.position;
        // Atan returns angle to the vector
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
