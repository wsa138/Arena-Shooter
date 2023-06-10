using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirection : MonoBehaviour
{
    [SerializeField] Sprite sp1;

    Vector2 movementDirection;
    bool facingLeft = true;



    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        FlipSprite(movementDirection.x);
    }

    // Function takes a float representing input value on x and changes the sprite.
    private void FlipSprite(float inputX)
    {
        if (inputX < 0 && facingLeft == false)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            facingLeft = true;
        }
        if (inputX > 0 && facingLeft == true)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            facingLeft = false;
           // spRenderer.flipX = true;
        }
    }
}
