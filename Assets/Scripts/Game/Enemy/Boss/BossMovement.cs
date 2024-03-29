using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] float bossSpeed;

    private Rigidbody2D rb;
    private PolygonCollider2D rbCollider;
    private Camera mainCamera;
    private float additionalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // Boss rigidbody
        rb = GetComponent<Rigidbody2D>();
        // Boss collider
        rbCollider = GetComponent<PolygonCollider2D>();
        mainCamera = Camera.main;

        rb.velocity = Vector2.right * bossSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (rbCollider != null)
        {
            // Bounds of boss game object
            Bounds rbBounds = rbCollider.bounds;
            // Min bound of boss in camera view. (Left side of ship)
            Vector2 minViewportPos = mainCamera.WorldToViewportPoint(rbBounds.min);
            // Max bound of boss in camera view. (Right side of ship)
            Vector2 maxViewportPos = mainCamera.WorldToViewportPoint(rbBounds.max);

            // Check if boss is hitting out of bounds.
            if (maxViewportPos.x >= 1 || minViewportPos.x <= 0)
            {
                // Add a random amount of speed to the boss.
                additionalSpeed = Random.Range(1f, 5f);
                bossSpeed += additionalSpeed;

                if (maxViewportPos.x > 1)
                {                    
                    rb.velocity = Vector2.left * bossSpeed;
                }

                if (minViewportPos.x < 0)
                {
                    rb.velocity = Vector2.right * bossSpeed;                    
                }
                // Reset the boss speed.
                bossSpeed -= additionalSpeed;
            }            
        }
    }
}
