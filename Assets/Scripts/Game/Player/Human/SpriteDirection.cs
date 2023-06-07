using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirection : MonoBehaviour
{
    [SerializeField] Sprite sp1;
    [SerializeField] Sprite sp2;
    [SerializeField] SpriteRenderer spRenderer;

    Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        FlipSprite(movementDirection.x);
    }

    // Function takes a float from GetInput() and changes the sprite.
    private void FlipSprite(float inputX)
    {
        // Access the sprite renderer of the child Human object.
        SpriteRenderer humanSpriteRenderer = spRenderer.GetComponent<SpriteRenderer>();

        if (inputX < 0)
        {
            humanSpriteRenderer.sprite = sp1;
        }
        if (inputX > 0)
        {
            humanSpriteRenderer.sprite = sp2;
        }
    }
}
